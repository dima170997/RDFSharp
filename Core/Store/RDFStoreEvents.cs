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

namespace RDFSharp.Store {

    /// <summary>
    /// RDFStoreEvents represents a collector for all the events generated within the "RDFSharp.Store" namespace
    /// </summary>
    public static class RDFStoreEvents {

        #region OnStoreInfo
        /// <summary>
        /// Event representing an information message generated within the "RDFSharp.Store" namespace
        /// </summary>
        public static event RDFStoreInfoEventHandler OnStoreInfo = delegate { };

        /// <summary>
        /// Delegate to handle information events generated within the "RDFSharp.Store" namespace
        /// </summary>
        public delegate void RDFStoreInfoEventHandler(String eventMessage);

        /// <summary>
        /// Internal invoker of the subscribed information event handler
        /// </summary>
        internal static void RaiseStoreInfo(String eventMessage) {
            RDFStoreEvents.OnStoreInfo(DateTime.Now.ToString() + " - " + eventMessage);
        }
        #endregion

        #region OnStoreWarning
        /// <summary>
        /// Event representing a warning message generated within the "RDFSharp.Store" namespace
        /// </summary>
        public static event RDFStoreWarningEventHandler OnStoreWarning = delegate { };

        /// <summary>
        /// Delegate to handle warning events generated within the "RDFSharp.Store" namespace
        /// </summary>
        public delegate void RDFStoreWarningEventHandler(String eventMessage);

        /// <summary>
        /// Internal invoker of the subscribed warning event handler
        /// </summary>
        internal static void RaiseStoreWarning(String eventMessage) {
            RDFStoreEvents.OnStoreWarning(DateTime.Now.ToString() + " - " + eventMessage);
        }
        #endregion

    }

}