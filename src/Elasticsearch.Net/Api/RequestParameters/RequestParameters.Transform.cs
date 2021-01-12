// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗  
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝  
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝
// -----------------------------------------------
//  
// This file is automatically generated 
// Please do not edit these files manually
// Run the following in the root of the repos:
//
// 		*NIX 		:	./build.sh codegen
// 		Windows 	:	build.bat codegen
//
// -----------------------------------------------
// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Elastic.Transport;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.TransformApi
{
	///<summary>Request options for Delete <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/delete-transform.html</para></summary>
	public class DeleteTransformRequestParameters : RequestParameters<DeleteTransformRequestParameters>
	{
		///<summary>
		/// When `true`, the transform is deleted regardless of its current state. The default value is `false`, meaning that the transform must be
		/// `stopped` before it can be deleted.
		///</summary>
		public bool? Force
		{
			get => Q<bool? >("force");
			set => Q("force", value);
		}
	}

	///<summary>Request options for Get <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform.html</para></summary>
	public class GetTransformRequestParameters : RequestParameters<GetTransformRequestParameters>
	{
		///<summary>Whether to ignore if a wildcard expression matches no transforms. (This includes `_all` string or when no transforms have been specified)</summary>
		public bool? AllowNoMatch
		{
			get => Q<bool? >("allow_no_match");
			set => Q("allow_no_match", value);
		}

		///<summary>Omits fields that are illegal to set on transform PUT</summary>
		public bool? ExcludeGenerated
		{
			get => Q<bool? >("exclude_generated");
			set => Q("exclude_generated", value);
		}

		///<summary>skips a number of transform configs, defaults to 0</summary>
		public int? From
		{
			get => Q<int? >("from");
			set => Q("from", value);
		}

		///<summary>specifies a max number of transforms to get, defaults to 100</summary>
		public int? Size
		{
			get => Q<int? >("size");
			set => Q("size", value);
		}
	}

	///<summary>Request options for GetStats <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/get-transform-stats.html</para></summary>
	public class GetTransformStatsRequestParameters : RequestParameters<GetTransformStatsRequestParameters>
	{
		///<summary>Whether to ignore if a wildcard expression matches no transforms. (This includes `_all` string or when no transforms have been specified)</summary>
		public bool? AllowNoMatch
		{
			get => Q<bool? >("allow_no_match");
			set => Q("allow_no_match", value);
		}

		///<summary>skips a number of transform stats, defaults to 0</summary>
		public long? From
		{
			get => Q<long? >("from");
			set => Q("from", value);
		}

		///<summary>specifies a max number of transform stats to get, defaults to 100</summary>
		public long? Size
		{
			get => Q<long? >("size");
			set => Q("size", value);
		}
	}

	///<summary>Request options for Preview <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/preview-transform.html</para></summary>
	public class PreviewTransformRequestParameters : RequestParameters<PreviewTransformRequestParameters>
	{
	}

	///<summary>Request options for Put <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/put-transform.html</para></summary>
	public class PutTransformRequestParameters : RequestParameters<PutTransformRequestParameters>
	{
		///<summary>If validations should be deferred until transform starts, defaults to false.</summary>
		public bool? DeferValidation
		{
			get => Q<bool? >("defer_validation");
			set => Q("defer_validation", value);
		}
	}

	///<summary>Request options for Start <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/start-transform.html</para></summary>
	public class StartTransformRequestParameters : RequestParameters<StartTransformRequestParameters>
	{
		///<summary>Controls the time to wait for the transform to start</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}
	}

	///<summary>Request options for Stop <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/stop-transform.html</para></summary>
	public class StopTransformRequestParameters : RequestParameters<StopTransformRequestParameters>
	{
		///<summary>Whether to ignore if a wildcard expression matches no transforms. (This includes `_all` string or when no transforms have been specified)</summary>
		public bool? AllowNoMatch
		{
			get => Q<bool? >("allow_no_match");
			set => Q("allow_no_match", value);
		}

		///<summary>Whether to force stop a failed transform or not. Default to false</summary>
		public bool? Force
		{
			get => Q<bool? >("force");
			set => Q("force", value);
		}

		///<summary>Controls the time to wait until the transform has stopped. Default to 30 seconds</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}

		///<summary>Whether to wait for the transform to reach a checkpoint before stopping. Default to false</summary>
		public bool? WaitForCheckpoint
		{
			get => Q<bool? >("wait_for_checkpoint");
			set => Q("wait_for_checkpoint", value);
		}

		///<summary>Whether to wait for the transform to fully stop before returning or not. Default to false</summary>
		public bool? WaitForCompletion
		{
			get => Q<bool? >("wait_for_completion");
			set => Q("wait_for_completion", value);
		}
	}

	///<summary>Request options for Update <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/update-transform.html</para></summary>
	public class UpdateTransformRequestParameters : RequestParameters<UpdateTransformRequestParameters>
	{
		///<summary>If validations should be deferred until transform starts, defaults to false.</summary>
		public bool? DeferValidation
		{
			get => Q<bool? >("defer_validation");
			set => Q("defer_validation", value);
		}
	}
}