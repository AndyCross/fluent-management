﻿using System;
using System.Collections.Generic;
using Elastacloud.AzureManagement.Fluent.Helpers;
using Elastacloud.AzureManagement.Fluent.Types;
using Elastacloud.AzureManagement.Fluent.Types.Websites;

namespace Elastacloud.AzureManagement.Fluent.Clients.Interfaces
{
    /// <summary>
    /// The interface used to roll out websites 
    /// </summary>
    public interface IWebsiteClient
    {
        /// <summary>
        /// Returns a list of websites
        /// </summary>
        List<Website> List();

        /// <summary>
        /// Creates a website given github credentials
        /// </summary>
        /// <param name="website"></param>
        /// <param name="gitDetails">the details of the github repo</param>
        void CreateFromGithub(Website website, GitDetails gitDetails);
        /// <summary>
        /// As above but using BitBucket instead
        /// </summary>
        void CreateFromBitBucket(Website website, GitDetails gitDetails);

        /// <summary>
        /// Creates a default website with nothing deployed
        /// </summary>
        /// <param name="website">the website which will be used</param>
        /// <param name="scm">The type of source control repo used</param>
        void Create(Website website, ScmType scm = ScmType.LocalGit);
        /// <summary>
        /// Deletes a website with the current context
        /// </summary>
        void Delete();
        /// <summary>
        /// Gets or sets the number of instances of the website
        /// </summary>
        int InstanceCount { get; set; }
        /// <summary>
        /// Gets or sets the compute of the site
        /// </summary>
        ComputeMode ComputeMode { get; set; }
        /// <summary>
        /// Restarts the website from a stopped state
        /// </summary>
        void Restart();
        /// <summary>
        /// Stops the website if it is currently running
        /// </summary>
        void Stop();
        /// <summary>
        /// The name of the website
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Updates the config with the current compute config
        /// </summary>
        void Update();
        /// <summary>
        /// Gets the website metrics in the requested interval backwards from datetime.now
        /// </summary>
        List<WebsiteMetric> GetWebsiteMetricsPerInterval(TimeSpan span);
    }
}