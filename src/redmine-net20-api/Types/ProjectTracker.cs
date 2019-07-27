﻿/*
   Copyright 2011 - 2019 Adrian Popescu.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System.Xml.Serialization;
using RedmineClient.Internals;

namespace RedmineClient.Types
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(RedmineKeys.TRACKER)]
    public sealed class ProjectTracker : IdentifiableName, IValue
    {
        /// <summary>
        /// 
        /// </summary>
        public ProjectTracker(){}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trackerId">the tracker id: 1 for Bug, etc.</param>
        /// <param name="name"></param>
        public ProjectTracker(int trackerId, string name)
        {
            Id = trackerId;
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trackerId"></param>
        internal ProjectTracker(int trackerId)
        {
            Id = trackerId;
        }

        /// <summary>
        /// 
        /// </summary>
		public string Value => Id.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public override string ToString()
        {
            return $"[{nameof(ProjectTracker)}: {base.ToString()}]";
        }
    }
}