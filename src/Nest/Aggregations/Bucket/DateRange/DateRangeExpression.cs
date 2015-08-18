﻿using System;
using Nest.Resolvers.Converters;
using Newtonsoft.Json;

namespace Nest
{
	[JsonConverter(typeof(ReadAsTypeJsonConverter<DateRangeExpression>))]
	public interface IDateRangeExpression : INestSerializable
	{
		[JsonProperty(PropertyName = "from")]
		DateMath From { get; set; }

		[JsonProperty(PropertyName = "to")]
		DateMath To { get; set; }

		[JsonProperty(PropertyName = "key")]
		string Key { get; set; }
	}

	public class DateRangeExpression : IDateRangeExpression
	{
		public DateMath From { get; set; }

		public DateMath To { get; set; }

		public string Key { get; set; }
	}

	public class DateRangeExpressionDescriptor : IDateRangeExpression
	{
		protected DateRangeExpressionDescriptor Assign(Action<IDateRangeExpression> assigner) => Fluent.Assign(this, assigner);

		DateMath IDateRangeExpression.From { get; set; }
		public DateRangeExpressionDescriptor From(DateMath from) => Assign(a => a.From = from);

		DateMath IDateRangeExpression.To { get; set; }
		public DateRangeExpressionDescriptor To(DateMath to) => Assign(a => a.To = to);

		string IDateRangeExpression.Key { get; set; }
		public DateRangeExpressionDescriptor From(string key) => Assign(a => a.Key = key);
	}
}