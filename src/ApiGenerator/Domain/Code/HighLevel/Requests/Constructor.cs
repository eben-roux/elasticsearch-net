// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using ApiGenerator.Configuration;
using ApiGenerator.Domain.Specification;

namespace ApiGenerator.Domain.Code.HighLevel.Requests
{
	public class Constructor
	{
		private static readonly string Indent = $"{Environment.NewLine}\t\t";
		public string AdditionalCode { get; set; } = string.Empty;
		public string Body { get; set; }
		public string Description { get; set; }
		public string Generated { get; set; }
		public bool Parameterless { get; set; }

		public static IEnumerable<Constructor> DescriptorConstructors(CsharpNames names, UrlInformation url)
		{
			var m = names.DescriptorName;
			var generic = FirstGeneric(names.GenericsDeclaredOnDescriptor);
			var generateGeneric = !string.IsNullOrEmpty(generic);
			return GenerateConstructors(url, true, generateGeneric, m, generic);
		}

		public static IEnumerable<Constructor> RequestConstructors(CsharpNames names, UrlInformation url, bool inheritsFromPlainRequestBase)
		{
			var generic = FirstGeneric(names.GenericsDeclaredOnRequest);
			var generateGeneric = CodeConfiguration.GenericOnlyInterfaces.Contains(names.RequestInterfaceName) || !inheritsFromPlainRequestBase;
			return GenerateConstructors(url, inheritsFromPlainRequestBase, generateGeneric, names.RequestName, generic);
		}

		private static string FirstGeneric(string fullGenericString) =>
			fullGenericString?.Replace("<", "").Replace(">", "").Split(",").First().Trim();

		private static IEnumerable<Constructor> GenerateConstructors(
			UrlInformation url,
			bool inheritsFromPlainRequestBase,
			bool generateGeneric,
			string typeName,
			string generic
		)
		{
			var ctors = new List<Constructor>();

			// Include deprecated paths to ensure these are not removed (a breaking change) during 7.x releases.
			// For historical reasons, constructors for deprecated paths which specified a type where removed in 7.0 and
			// therefore we don't include those in generation to avoid them being re-added.
			var paths = url.Paths.ToList().Union(url.PathsWithDeprecations.Where(x => x.Parts.All(p => p.Name != "type")));

			if (url.IsPartless) return ctors;

			ctors.AddRange(from path in paths
				let baseArgs = inheritsFromPlainRequestBase ? path.RequestBaseArguments : path.TypedSubClassBaseArguments
				let constParams = path.ConstructorArguments
				let generated = $"public {typeName}({constParams}) : base({baseArgs})"
				select new Constructor
				{
					Parameterless = string.IsNullOrEmpty(constParams),
					Generated = generated,
					Description = path.GetXmlDocs(Indent),
					//Body = isDocumentApi ? $" => Q(\"routing\", new Routing(() => AutoRouteDocument()));" : string.Empty
					Body = string.Empty
				});

			if (generateGeneric && !string.IsNullOrWhiteSpace(generic))
			{
				ctors.AddRange(from path in paths.Where(path => path.HasResolvableArguments)
					let baseArgs = path.AutoResolveBaseArguments(generic)
					let constructorArgs = path.AutoResolveConstructorArguments
					let baseOrThis = inheritsFromPlainRequestBase
						? "this"
						: "base"
					let generated = $"public {typeName}({constructorArgs}) : {baseOrThis}({baseArgs})"
					select new Constructor
					{
						Parameterless = string.IsNullOrEmpty(constructorArgs),
						Generated = generated,
						Description = path.GetXmlDocs(Indent, true),
						Body = string.Empty
					});

				if (url.TryGetDocumentApiPath(out var docPath))
				{
					var docPathBaseArgs = docPath.DocumentPathBaseArgument(generic);
					var docPathConstArgs = docPath.DocumentPathConstructorArgument(generic);
					ctors.Add(new Constructor
					{
						Parameterless = string.IsNullOrEmpty(docPathConstArgs),
						Generated = $"public {typeName}({docPathConstArgs}) : this({docPathBaseArgs})",
						AdditionalCode = $"partial void DocumentFromPath({generic} document);",
						Description = docPath.GetXmlDocs(Indent, true, true),
						Body = "=> DocumentFromPath(documentWithId);"
					});
				}
			}
			var constructors = ctors.GroupBy(c => c.Generated.Split(new[] { ':' }, 2)[0]).Select(g => g.Last()).ToList();
			if (!constructors.Any(c => c.Parameterless))
				constructors.Add(new Constructor
				{
					Parameterless = true,
					Generated = $"protected {typeName}() : base()",
					Description =
						$"///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>{Indent}[SerializationConstructor]",
				});
			return constructors;
		}
	}
}
