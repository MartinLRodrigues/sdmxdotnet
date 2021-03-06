using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OXM;
using Common;

namespace SDMX.Parsers
{
    internal abstract class MeasureMap<T> : AnnotableArtefactMap<T>
            where T : Measure
    {
        protected abstract T Create(Concept conecpt);

        T _measure;
        
        internal MeasureMap(StructureMessage message)
        {
            Map(o => TempConceptRef.Create(o.Concept)).ToAttributeGroup("conceptRef")
               .Set(v => _measure = Create(message.GetConcept(v.ID, v.AgencyID, v.Version)))
               .GroupTypeMap(new TempConceptRefMap());

            Map(o => TempCodelistRef.Create(o.CodeList)).ToAttributeGroup("codelist")
                .Set(v => _measure.CodeList = message.GetCodeList(v.ID, v.AgencyID, v.Version))
                .GroupTypeMap(new TempCodelistRefMap());

            Map(o => o.TextFormat).ToElement("TextFormat", false)
                 .Set(v => _measure.TextFormat = v)
                 .ClassMap(() => new TextFormatMap());
        }     
    }
}
