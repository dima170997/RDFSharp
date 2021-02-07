using RDFSharp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDFSharp.Semantics.OWL
{
    /// <summary>
    /// RDFBASEOntology represents a partial OWL-DL ontology implementation of base vocabularies (RDF/RDFS/OWL/XSD).
    /// </summary>
    public static class RDFBASEOntology
    {

        #region Properties
        /// <summary>
        /// Singleton instance of the BASE ontology
        /// </summary>
        public static RDFOntology Instance { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the BASE ontology
        /// </summary>
        static RDFBASEOntology()
        {

            #region Declarations

            Instance = new RDFOntology(new RDFResource(RDFVocabulary.RDFSHARP.BASE_URI));

            //Datatypes
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.RDF.XML_LITERAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.ANY_URI.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.BASE64_BINARY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.BOOLEAN.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.BYTE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DATE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DOUBLE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.DURATION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.FLOAT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_DAY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_MONTH.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_MONTH_DAY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_YEAR.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.G_YEAR_MONTH.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.HEX_BINARY.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.INT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.LANGUAGE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.LONG.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NAME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NCNAME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NEGATIVE_INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NMTOKEN.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.NOTATION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.POSITIVE_INTEGER.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.QNAME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.SHORT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.STRING.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.TIME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.UNSIGNED_BYTE.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass());

            //Classes
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.THING.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.OWL.NOTHING.ToRDFOntologyClass());

            #endregion

            #region Taxonomies

            //SubClassOf
            var subClassOf = RDFVocabulary.RDFS.SUB_CLASS_OF.ToRDFOntologyObjectProperty();
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.RDF.XML_LITERAL.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.STRING.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BOOLEAN.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BASE64_BINARY.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.HEX_BINARY.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.FLOAT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DOUBLE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.ANY_URI.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.QNAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NOTATION.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DURATION.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.TIME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DATE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_YEAR_MONTH.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_YEAR.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_MONTH_DAY.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_DAY.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_MONTH.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATE.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.STRING.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.LANGUAGE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NMTOKEN.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NCNAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NAME.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.LONG.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NEGATIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.INT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.LONG.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INT.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.SHORT.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.POSITIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass()));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass()));

            #endregion

            #region Materializations

            //SubClassOf
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INT.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.LONG.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.INT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.INT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.INT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.LONG.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.LONG.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.LONG.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_BYTE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_INT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.UNSIGNED_LONG.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.UNSIGNED_SHORT.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NEGATIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NEGATIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NEGATIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.POSITIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.INTEGER.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.POSITIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.POSITIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NON_NEGATIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DECIMAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NON_POSITIVE_INTEGER.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.DATE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.TIME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_DAY.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_DAY.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_MONTH.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_MONTH.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_MONTH_DAY.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_MONTH_DAY.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_YEAR.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_YEAR.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_YEAR_MONTH.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.DATETIME.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.G_YEAR_MONTH.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.LANGUAGE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.LANGUAGE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.STRING.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.LANGUAGE.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.STRING.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NCNAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NCNAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NCNAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.STRING.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NCNAME.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NMTOKEN.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.NORMALIZED_STRING.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NMTOKEN.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.STRING.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.NMTOKEN.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass(), subClassOf, RDFVocabulary.XSD.STRING.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));
            Instance.Model.ClassModel.Relations.SubClassOf.AddEntry(new RDFOntologyTaxonomyEntry(RDFVocabulary.XSD.TOKEN.ToRDFOntologyClass(), subClassOf, RDFVocabulary.RDFS.LITERAL.ToRDFOntologyClass()).SetInference(RDFSemanticsEnums.RDFOntologyInferenceType.API));

            #endregion

        }
        #endregion

    }
}