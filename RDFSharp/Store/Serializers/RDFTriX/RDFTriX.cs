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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using RDFSharp.Model;

namespace RDFSharp.Store {

    /// <summary>
    /// RDFTriX is responsible for managing serialization to and from TriX data format.
    /// </summary>
    internal static class RDFTriX {

        #region Methods

        #region Write
        /// <summary>
        /// Serializes the given store to the given filepath using TriX data format. 
        /// </summary>
        internal static void Serialize(RDFStore store, String filepath) {
            Serialize(store, new FileStream(filepath, FileMode.Create));
        }

        /// <summary>
        /// Serializes the given store to the given stream using TriX data format. 
        /// </summary>
        internal static void Serialize(RDFStore store, Stream outputStream) {
            try {

                #region serialize
                using (XmlTextWriter trixWriter = new XmlTextWriter(outputStream, Encoding.UTF8)) {
                    XmlDocument trixDoc         = new XmlDocument();
                    trixWriter.Formatting       = Formatting.Indented;

                    #region xmlDecl
                    XmlDeclaration trixDecl     = trixDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    trixDoc.AppendChild(trixDecl);
                    #endregion

                    #region trixRoot
                    XmlNode trixRoot            = trixDoc.CreateNode(XmlNodeType.Element, "TriX", null);
                    XmlAttribute trixRootNS     = trixDoc.CreateAttribute("xmlns");
                    XmlText trixRootNSText      = trixDoc.CreateTextNode("http://www.w3.org/2004/03/trix/trix-1/");
                    trixRootNS.AppendChild(trixRootNSText);
                    trixRoot.Attributes.Append(trixRootNS);

                    #region graphs
                    foreach (var graph             in store.ExtractGraphs()) {
                        XmlNode graphElement        = trixDoc.CreateNode(XmlNodeType.Element, "graph", null);
                        XmlNode graphUriElement     = trixDoc.CreateNode(XmlNodeType.Element, "uri", null);
                        XmlText graphUriElementT    = trixDoc.CreateTextNode(graph.ToString());
                        graphUriElement.AppendChild(graphUriElementT);
                        graphElement.AppendChild(graphUriElement);

                        #region triple
                        foreach(var t in graph) {
                            XmlNode tripleElement   = trixDoc.CreateNode(XmlNodeType.Element, "triple", null);

                            #region subj
                            XmlNode subjElement     = null;
                            XmlText subjElementText = null;
                            if(((RDFResource)t.Subject).IsBlank) {
                                subjElement         = trixDoc.CreateNode(XmlNodeType.Element, "id", null);
                                subjElementText     = trixDoc.CreateTextNode(t.Subject.ToString().Replace("bnode:", String.Empty));
                            }
                            else {
                                subjElement         = trixDoc.CreateNode(XmlNodeType.Element, "uri", null);
                                subjElementText     = trixDoc.CreateTextNode(t.Subject.ToString());
                            }
                            subjElement.AppendChild(subjElementText);
                            tripleElement.AppendChild(subjElement);
                            #endregion

                            #region pred
                            XmlNode uriElementP     = trixDoc.CreateNode(XmlNodeType.Element, "uri", null);
                            XmlText uriTextP        = trixDoc.CreateTextNode(t.Predicate.ToString());
                            uriElementP.AppendChild(uriTextP);
                            tripleElement.AppendChild(uriElementP);
                            #endregion

                            #region object
                            if(t.TripleFlavor         == RDFModelEnums.RDFTripleFlavors.SPO) {
                                XmlNode objElement     = null;
                                XmlText objElementText = null;
                                if(((RDFResource)t.Object).IsBlank) {
                                    objElement         = trixDoc.CreateNode(XmlNodeType.Element, "id", null);
                                    objElementText     = trixDoc.CreateTextNode(t.Object.ToString().Replace("bnode:", String.Empty));
                                }
                                else {
                                    objElement         = trixDoc.CreateNode(XmlNodeType.Element, "uri", null);
                                    objElementText     = trixDoc.CreateTextNode(t.Object.ToString());
                                }
                                objElement.AppendChild(objElementText);
                                tripleElement.AppendChild(objElement);
                            }
                            #endregion

                            #region literal
                            else {

                                #region plain literal
                                if (t.Object is RDFPlainLiteral) {
                                    XmlNode plainLiteralElement = trixDoc.CreateNode(XmlNodeType.Element, "plainLiteral", null);
                                    if(((RDFPlainLiteral)t.Object).Language != String.Empty) {
                                        XmlAttribute xmlLang    = trixDoc.CreateAttribute(RDFVocabulary.XML.PREFIX + ":lang", RDFVocabulary.XML.BASE_URI);
                                        XmlText xmlLangText     = trixDoc.CreateTextNode(((RDFPlainLiteral)t.Object).Language);
                                        xmlLang.AppendChild(xmlLangText);
                                        plainLiteralElement.Attributes.Append(xmlLang);
                                    }
                                    XmlText plainLiteralText    = trixDoc.CreateTextNode(HttpUtility.HtmlDecode(((RDFLiteral)t.Object).Value));
                                    plainLiteralElement.AppendChild(plainLiteralText);
                                    tripleElement.AppendChild(plainLiteralElement);
                                }
                                #endregion

                                #region typed literal
                                else {
                                    XmlNode typedLiteralElement = trixDoc.CreateNode(XmlNodeType.Element, "typedLiteral", null);
                                    XmlAttribute datatype       = trixDoc.CreateAttribute("datatype");
                                    XmlText datatypeText        = trixDoc.CreateTextNode(((RDFTypedLiteral)t.Object).Datatype.ToString());
                                    datatype.AppendChild(datatypeText);
                                    typedLiteralElement.Attributes.Append(datatype);
                                    XmlText typedLiteralText    = trixDoc.CreateTextNode(HttpUtility.HtmlDecode(((RDFLiteral)t.Object).Value));
                                    typedLiteralElement.AppendChild(typedLiteralText);
                                    tripleElement.AppendChild(typedLiteralElement);
                                }
                                #endregion

                            }
                            #endregion

                            graphElement.AppendChild(tripleElement);
                        }
                        #endregion

                        trixRoot.AppendChild(graphElement);
                    }                    
                    #endregion

                    trixDoc.AppendChild(trixRoot);
                    #endregion

                    trixDoc.Save(trixWriter);
                }
                #endregion

            }
            catch(Exception ex) {
                throw new RDFStoreException("Cannot serialize TriX because: " + ex.Message, ex);
            }
        }
        #endregion

        #region Read
        /// <summary>
        /// Deserializes the given TriX filepath to a memory store. 
        /// </summary>
        internal static RDFMemoryStore Deserialize(String filepath) {
            return Deserialize(new FileStream(filepath, FileMode.Open));
        }

        /// <summary>
        /// Deserializes the given TriX stream to a memory store. 
        /// </summary>
        internal static RDFMemoryStore Deserialize(Stream inputStream) {
            try {

                #region deserialize
                XmlReaderSettings xrs                   = new XmlReaderSettings();
                xrs.IgnoreComments                      = true;
                xrs.DtdProcessing                       = DtdProcessing.Ignore;

                RDFMemoryStore result                   = new RDFMemoryStore();
                Dictionary<Int64, RDFGraph> graphs      = new Dictionary<Int64, RDFGraph>();
                using (XmlReader xr                     = XmlReader.Create(new StreamReader(inputStream, Encoding.UTF8), xrs)) {

                    #region load
                    XmlDocument trixDoc                 = new XmlDocument();
                    trixDoc.Load(xr);
                    #endregion

                    #region graph
                    if (trixDoc.DocumentElement        != null) {

                        #region graphs extraction
                        var graphEnum                   = trixDoc.DocumentElement.ChildNodes.GetEnumerator();
                        while (graphEnum               != null && graphEnum.MoveNext()) {
                            XmlNode  graph              = (XmlNode)graphEnum.Current;
                            if (!graph.Name.Equals("graph", StringComparison.Ordinal)) {
                                 throw new Exception(" a \"<graph>\" element was expected, instead of unrecognized \"<" + graph.Name + ">\".");
                            }
                            Uri   graphUri              = RDFNamespaceRegister.DefaultNamespace.Namespace;
                            Int64 graphID               = RDFNamespaceRegister.DefaultNamespace.NamespaceID;
                            if (!graphs.ContainsKey(graphID)) {
                                 graphs.Add(graphID, new RDFGraph().SetContext(graphUri));
                            }

                            #region triple
                            var encodedUris             = 0;
                            var tripleEnum              = graph.ChildNodes.GetEnumerator();
                            while(tripleEnum           != null && tripleEnum.MoveNext()) {
                                XmlNode triple          = (XmlNode)tripleEnum.Current;

                                #region uri
                                if (triple.Name.Equals("uri", StringComparison.Ordinal)) {
                                    encodedUris++;
                                    if (encodedUris     > 1) {
                                        throw new Exception(" given file encodes a graph with more than one \"<uri>\" element.");
                                    }

                                    graphUri            = RDFModelUtilities.GetUriFromString(triple.ChildNodes[0].InnerText);
                                    graphID             = RDFModelUtilities.CreateHash(graphUri.ToString());
                                    if (!graphs.ContainsKey(graphID)) {
                                         graphs.Add(graphID, new RDFGraph().SetContext(graphUri));
                                    }
                                }
                                #endregion

                                #region triple
                                else if(triple.Name.Equals("triple", StringComparison.Ordinal) && triple.ChildNodes.Count == 3) {

                                    #region subj
                                    //Subject is a resource ("<uri>") or a blank node ("<id>")
                                    if (triple.ChildNodes[0].Name.Equals("uri", StringComparison.Ordinal) ||
                                        triple.ChildNodes[0].Name.Equals("id", StringComparison.Ordinal))  {
                                        //Sanitize eventual blank node value
                                        if (triple.ChildNodes[0].Name.Equals("id", StringComparison.Ordinal)) {
                                            if (!triple.ChildNodes[0].InnerText.StartsWith("bnode:")) {
                                                 triple.ChildNodes[0].InnerText = "bnode:" + triple.ChildNodes[0].InnerText.Replace("_:", String.Empty);
                                            }
                                        }
                                    }
                                    //Subject is not valid: exception must be raised
                                    else {
                                        throw new RDFModelException("subject (" + triple.ChildNodes[0].Name + ") of \"<triple>\" element is neither \"<uri>\" or \"<id>\".");
                                    }
                                    #endregion

                                    #region pred
                                    //Predicate is not valid: exception must be raised
                                    if (!triple.ChildNodes[1].Name.Equals("uri", StringComparison.Ordinal)) {
                                         throw new RDFModelException("predicate (" + triple.ChildNodes[1].Name + ") of \"<triple>\" element must be \"<uri>\".");
                                    }
                                    #endregion

                                    #region object
                                    //Object is a resource ("<uri>") or a blank node ("<id>")
                                    if (triple.ChildNodes[2].Name.Equals("uri", StringComparison.Ordinal) ||
                                        triple.ChildNodes[2].Name.Equals("id", StringComparison.Ordinal)) {
                                        //Sanitize eventual blank node value
                                        if (triple.ChildNodes[2].Name.Equals("id", StringComparison.Ordinal)) {
                                            if (!triple.ChildNodes[2].InnerText.StartsWith("bnode:")) {
                                                 triple.ChildNodes[2].InnerText = "bnode:" + triple.ChildNodes[2].InnerText.Replace("_:", String.Empty);
                                            }
                                        }
                                        graphs[graphID].AddTriple(new RDFTriple(new RDFResource(triple.ChildNodes[0].InnerText),
                                                                                new RDFResource(triple.ChildNodes[1].InnerText),
                                                                                new RDFResource(triple.ChildNodes[2].InnerText)));
                                    }
                                    #endregion

                                    #region literal

                                    #region plain literal
                                    else if(triple.ChildNodes[2].Name.Equals("plainLiteral")) {
                                        if (triple.ChildNodes[2].Attributes != null && triple.ChildNodes[2].Attributes.Count > 0) {
                                            XmlAttribute xmlLang = triple.ChildNodes[2].Attributes[RDFVocabulary.XML.PREFIX + ":lang"];
                                            if (xmlLang         != null) {

                                                //Plain literal with language
                                                graphs[graphID].AddTriple(new RDFTriple(new RDFResource(triple.ChildNodes[0].InnerText),
                                                                                        new RDFResource(triple.ChildNodes[1].InnerText),
                                                                                        new RDFPlainLiteral(HttpUtility.HtmlDecode(triple.ChildNodes[2].InnerText), xmlLang.Value)));

                                            }
                                            else {

                                                //Plain literal without language
                                                graphs[graphID].AddTriple(new RDFTriple(new RDFResource(triple.ChildNodes[0].InnerText),
                                                                                        new RDFResource(triple.ChildNodes[1].InnerText),
                                                                                        new RDFPlainLiteral(HttpUtility.HtmlDecode(triple.ChildNodes[2].InnerText))));

                                            }
                                        }
                                        else {

                                            //Plain literal without language
                                            graphs[graphID].AddTriple(new RDFTriple(new RDFResource(triple.ChildNodes[0].InnerText),
                                                                                    new RDFResource(triple.ChildNodes[1].InnerText),
                                                                                    new RDFPlainLiteral(HttpUtility.HtmlDecode(triple.ChildNodes[2].InnerText))));

                                        }
                                    }
                                    #endregion

                                    #region typed literal
                                    else if(triple.ChildNodes[2].Name.Equals("typedLiteral", StringComparison.Ordinal)) {
                                        if (triple.ChildNodes[2].Attributes != null && triple.ChildNodes[2].Attributes.Count > 0) {
                                            XmlAttribute rdfDtype = triple.ChildNodes[2].Attributes["datatype"];
                                            if (rdfDtype         != null) {
                                                graphs[graphID].AddTriple(new RDFTriple(new RDFResource(triple.ChildNodes[0].InnerText),
                                                                                        new RDFResource(triple.ChildNodes[1].InnerText),
                                                                                        new RDFTypedLiteral(HttpUtility.HtmlDecode(triple.ChildNodes[2].InnerText), RDFModelUtilities.GetDatatypeFromString(rdfDtype.Value))));
                                            }
                                            else {
                                                throw new Exception(" found typed literal without required \"datatype\" attribute.");
                                            }
                                        }
                                        else {
                                            throw new Exception(" found typed literal without required \"datatype\" attribute.");
                                        }
                                    }
                                    #endregion

                                    #endregion

                                    #region exception
                                    //Object is not valid: exception must be raised
                                    else {
                                        throw new RDFModelException("object (" + triple.ChildNodes[2].Name + ") of \"<triple>\" element is neither \"<uri>\" or \"<id>\" or \"<plainLiteral>\" or \"<typedLiteral>\".");
                                    }
                                    #endregion

                                }
                                #endregion

                                #region exception
                                else {
                                    throw new RDFModelException("found a TriX element (" + triple.Name + ") which is neither \"<uri>\" or \"<triple>\", or is a \"<triple>\" without the required 3 childs.");
                                }
                                #endregion

                            }
                            #endregion

                        }
                        #endregion

                        #region graphs merging
                        foreach(var graph              in graphs) {
                            result.MergeGraph(graph.Value);
                        }
                        #endregion

                    }
                    #endregion

                }
                return result;
                #endregion

            }
            catch(Exception ex) {
                throw new RDFModelException("Cannot deserialize TriX because: " + ex.Message, ex);
            }
        }
        #endregion

        #endregion

    }

}