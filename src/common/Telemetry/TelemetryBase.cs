// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// WARNING: THIS FILE GETS REPLACED ON THE BUILD FARM
using System.Diagnostics.Tracing;

namespace Microsoft.PowerToys.Telemetry
{
    /// <summary>
    /// Privacy Tag values
    /// </summary>
    public enum PartA_PrivTags
           : ulong
    {
        /// <nodoc/>
        None = 0,

        /// <nodoc/>
        ProductAndServicePerformance = 1,

        /// <nodoc/>
        ProductAndServiceUsage = 2,
    }

    /// <summary>
    /// Base class for telemetry events.
    /// </summary>
    public class TelemetryBase : EventSource
    {
        /// <summary>
        /// The event category DropPii tag.
        /// </summary>
        public const EventTags DropPii = (EventTags)0x02000000;

        /// <summary>
        /// The event tag for this event source.
        /// </summary>
        public const EventTags ProjectTelemetryTagProductAndServicePerformance = (EventTags)0x0000000001000000u;

        /// <summary>
        /// The event keyword for this event source.
        /// </summary>
        public const EventKeywords ProjectKeywordMeasure = (EventKeywords)0x0000400000000000;

        /// <summary>
        /// Group ID for Powertoys project.
        /// </summary>
        private static readonly string[] PowerToysTelemetryTraits = { "MSPG_GROUP", "{5ecb0bac-b930-47f5-a8a4-e8253529edb7}" };

        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryBase"/> class.
        /// </summary>
        /// <param name="eventSourceName">.</param>
        public TelemetryBase(
            string eventSourceName)
            : base(
            eventSourceName,
            EventSourceSettings.EtwSelfDescribingEventFormat,
            PowerToysTelemetryTraits)
        {
            return;
        }
    }
}
