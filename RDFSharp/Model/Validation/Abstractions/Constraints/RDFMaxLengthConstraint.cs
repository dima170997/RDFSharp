﻿using RDFSharp.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDFSharp.Model.Validation
{
    /// <summary>
    /// RDFMaxLengthConstraint represents a SHACL constraint on the maximum allowed length for a given RDF term
    /// </summary>
    public class RDFMaxLengthConstraint: RDFConstraint {

        #region Properties
        /// <summary>
        /// Indicates the maximum allowed length for a given RDF term
        /// </summary>
        public uint MaxLength { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build a SHACL maxlength constraint
        /// </summary>
        public RDFMaxLengthConstraint(RDFResource constraintName, uint maxLength) : base(constraintName) {
            this.MaxLength = maxLength;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Evaluates this SHACL constraint against the given data graph
        /// </summary>
        internal override RDFValidationReport EvaluateConstraint(RDFShapesGraph shapesGraph, 
                                                                 RDFShape shape, 
                                                                 RDFGraph dataGraph, 
                                                                 RDFResource focusNode,
                                                                 RDFPatternMember valueNode) {
            var report = new RDFValidationReport(new RDFResource());
            switch (valueNode) {

                //Resource
                case RDFResource valueNodeResource:
                    if (valueNodeResource.IsBlank || valueNodeResource.ToString().Length > this.MaxLength) {
                        report.AddResult(new RDFValidationResult(shape,
                                                                 RDFVocabulary.SHACL.MAX_LENGTH_CONSTRAINT_COMPONENT,
                                                                 focusNode,
                                                                 shape is RDFPropertyShape ? ((RDFPropertyShape)shape).Path : null,
                                                                 valueNode,
                                                                 shape.Messages,
                                                                 new RDFResource(),
                                                                 shape.Severity));
                    }
                    break;

                //Literal
                case RDFLiteral valueNodeLiteral:
                    if (valueNodeLiteral.Value.Length > this.MaxLength) {
                        report.AddResult(new RDFValidationResult(shape,
                                                                 RDFVocabulary.SHACL.MAX_LENGTH_CONSTRAINT_COMPONENT,
                                                                 focusNode,
                                                                 shape is RDFPropertyShape ? ((RDFPropertyShape)shape).Path : null,
                                                                 valueNode,
                                                                 shape.Messages,
                                                                 new RDFResource(),
                                                                 shape.Severity));
                    }
                    break;

            }
            return report;
        }

        /// <summary>
        /// Gets a graph representation of this SHACL constraint
        /// </summary>
        public override RDFGraph ToRDFGraph(RDFShape shape) {
            var result = new RDFGraph();

            //sh:maxLength
            if (shape != null)
                result.AddTriple(new RDFTriple(shape, RDFVocabulary.SHACL.MAX_LENGTH, new RDFTypedLiteral(this.MaxLength.ToString(), RDFModelEnums.RDFDatatypes.XSD_INTEGER)));

            return result;
        }
        #endregion

    }
}