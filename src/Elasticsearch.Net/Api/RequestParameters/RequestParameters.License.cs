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
namespace Elasticsearch.Net.Specification.LicenseApi
{
	///<summary>Request options for Delete <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/delete-license.html</para></summary>
	public class DeleteLicenseRequestParameters : RequestParameters<DeleteLicenseRequestParameters>
	{
	}

	///<summary>Request options for Get <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/get-license.html</para></summary>
	public class GetLicenseRequestParameters : RequestParameters<GetLicenseRequestParameters>
	{
		///<summary>Supported for backwards compatibility with 7.x. If this param is used it must be set to true</summary>
		[Obsolete("Scheduled to be removed in 8.0, Deprecated as of: 8.0.0, reason: Supported for backwards compatibility with 7.x. If this param is used it must be set to true")]
		public bool? AcceptEnterprise
		{
			get => Q<bool? >("accept_enterprise");
			set => Q("accept_enterprise", value);
		}

		///<summary>Return local information, do not retrieve the state from master node (default: false)</summary>
		public bool? Local
		{
			get => Q<bool? >("local");
			set => Q("local", value);
		}
	}

	///<summary>Request options for GetBasicStatus <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/get-basic-status.html</para></summary>
	public class GetBasicLicenseStatusRequestParameters : RequestParameters<GetBasicLicenseStatusRequestParameters>
	{
	}

	///<summary>Request options for GetTrialStatus <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/get-trial-status.html</para></summary>
	public class GetTrialLicenseStatusRequestParameters : RequestParameters<GetTrialLicenseStatusRequestParameters>
	{
	}

	///<summary>Request options for Post <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/update-license.html</para></summary>
	public class PostLicenseRequestParameters : RequestParameters<PostLicenseRequestParameters>
	{
		///<summary>whether the user has acknowledged acknowledge messages (default: false)</summary>
		public bool? Acknowledge
		{
			get => Q<bool? >("acknowledge");
			set => Q("acknowledge", value);
		}
	}

	///<summary>Request options for StartBasic <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/start-basic.html</para></summary>
	public class StartBasicLicenseRequestParameters : RequestParameters<StartBasicLicenseRequestParameters>
	{
		///<summary>whether the user has acknowledged acknowledge messages (default: false)</summary>
		public bool? Acknowledge
		{
			get => Q<bool? >("acknowledge");
			set => Q("acknowledge", value);
		}
	}

	///<summary>Request options for StartTrial <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/start-trial.html</para></summary>
	public class StartTrialLicenseRequestParameters : RequestParameters<StartTrialLicenseRequestParameters>
	{
		///<summary>whether the user has acknowledged acknowledge messages (default: false)</summary>
		public bool? Acknowledge
		{
			get => Q<bool? >("acknowledge");
			set => Q("acknowledge", value);
		}

		///<summary>The type of trial license to generate (default: "trial")</summary>
		public string TypeQueryString
		{
			get => Q<string>("type");
			set => Q("type", value);
		}
	}
}