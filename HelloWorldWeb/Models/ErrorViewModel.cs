// <copyright file="ErrorViewModel.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;

namespace HelloWorldWeb.Models
{
    /// <summary>
    /// Error view model.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets requestId property.
        /// Dummy commment.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether someting happened.
        /// dummy comment for lambda function.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
