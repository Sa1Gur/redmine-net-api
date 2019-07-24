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

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;
using RedmineClient.Extensions;
using RedmineClient.Internals;

namespace RedmineClient.Types
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(RedmineKeys.ISSUE)]
    public sealed class IssueChild : Identifiable<IssueChild>, ICloneable
    {
        #region Properties
        /// <summary>
        /// Gets or sets the tracker.
        /// </summary>
        /// <value>The tracker.</value>
        public IdentifiableName Tracker { get; internal set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string Subject { get; internal set; }
        #endregion

        #region Implementation of IXmlSerialization
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public override void ReadXml(XmlReader reader)
        {
            Id = Convert.ToInt32(reader.GetAttribute(RedmineKeys.ID));
            reader.Read();

            while (!reader.EOF)
            {
                if (reader.IsEmptyElement && !reader.HasAttributes)
                {
                    reader.Read();
                    continue;
                }

                switch (reader.Name)
                {
                    case RedmineKeys.TRACKER: Tracker = new IdentifiableName(reader); break;

                    case RedmineKeys.SUBJECT: Subject = reader.ReadElementContentAsString(); break;

                    default: reader.Read(); break;
                }
            }
        }
        #endregion

        #region Implementation of IJsonSerialization
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public override void ReadJson(JsonReader reader)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    return;
                }

                if (reader.TokenType != JsonToken.PropertyName)
                {
                    continue;
                }

                switch (reader.Value)
                {
                    case RedmineKeys.ID: Id = reader.ReadAsInt(); break;

                    case RedmineKeys.TRACKER: Tracker = new IdentifiableName(reader); break;

                    case RedmineKeys.SUBJECT: Subject = reader.ReadAsString(); break;

                    default: reader.Read(); break;
                }
            }
        }
        #endregion
        
        #region Implementation of IEquatable<IssueChild>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(IssueChild other)
        {
            if (other == null) return false;
            return (Id == other.Id && Tracker == other.Tracker && Subject == other.Subject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 13;
                hashCode = HashCodeHelper.GetHashCode(Id, hashCode);
                hashCode = HashCodeHelper.GetHashCode(Tracker, hashCode);
                hashCode = HashCodeHelper.GetHashCode(Subject, hashCode);
                return hashCode;
            }
        }
        #endregion 

        #region Implementation of IClonable

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
          var issueChild = new IssueChild { Subject = Subject, Tracker = Tracker };
          return issueChild;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{nameof(IssueChild)}: {base.ToString()}, Tracker={Tracker}, Subject={Subject}]";
        }
    }
}
