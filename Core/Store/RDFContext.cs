﻿/*
   Copyright 2012-2016 Marco De Salvo

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
using RDFSharp.Model;
using RDFSharp.Query;

namespace RDFSharp.Store
{

    /// <summary>
    /// RDFContext represents an object which can act as C-token of a pattern. 
	/// It cannot start with "bnode:" because blank contexts are not supported.
    /// </summary>
    public class RDFContext: RDFPatternMember {

        #region Properties
        /// <summary>
        /// Uri representing the context of the pattern
        /// </summary>
        public Uri Context { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build a predefined context
        /// </summary>
        public RDFContext() {
            this.Context         = RDFNamespaceRegister.DefaultNamespace.Namespace;
            this.PatternMemberID = RDFModelUtilities.CreateHash(this.ToString());   
        }

        /// <summary>
        /// String-based ctor to build a context from the given string 
        /// </summary>
        public RDFContext(String contextString): this() {
            Uri tempUri          = RDFModelUtilities.GetUriFromString(contextString);
            if (tempUri         != null) {
                if (!tempUri.ToString().ToUpperInvariant().StartsWith("BNODE:")) {
                     this.Context         = tempUri;
                     this.PatternMemberID = RDFModelUtilities.CreateHash(this.ToString());
                }
                else {
                     throw new RDFStoreException("Cannot create RDFContext because given \"contextString\" parameter represents a blank node Uri.");
                }
            }
        }

        /// <summary>
        /// Uri-based ctor to build a context from the given Uri
        /// </summary>
        public RDFContext(Uri contextUri): this() {
            if (contextUri      != null) {
                Uri tempUri      = RDFModelUtilities.GetUriFromString(contextUri.ToString());
                if (tempUri     != null) {
                    if (!tempUri.ToString().ToUpperInvariant().StartsWith("BNODE:")) {
                         this.Context         = tempUri;
                         this.PatternMemberID = RDFModelUtilities.CreateHash(this.ToString());
                    }
                    else {
                         throw new RDFStoreException("Cannot create RDFContext because given \"contextUri\" parameter represents a blank node Uri.");
                    }
                }
            }
        }
        #endregion

        #region Interfaces
        /// <summary>
        /// Gives the string representation of the store context
        /// </summary>
        public override String ToString() {
            return this.Context.ToString();
        }
        #endregion

    }

}
