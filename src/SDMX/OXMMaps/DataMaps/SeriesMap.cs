using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OXM;

namespace SDMX.Parsers
{
    internal class SeriesMap : AnnotableArtefactMap<Series>
    {
        Series _series;

        public SeriesMap(DataSet dataSet)
        {
            ElementsOrder("SeriesKey", "Attributes", "Obs", "Annotations");

            SeriesKey key = null;
            Map(o => o.Key).ToElement("SeriesKey", true)
                .Set(v => key = v)
                .ClassMap(() => new SeriesKeyMap(dataSet));

            MapContainer(Namespaces.Generic + "Attributes", false)
                .MapCollection(o => GetKeyValues(o.Attributes)).ToElement("Value", false)
                    .Set(v => dataSet.Attributes.Add(v.Concept, v.Value))
                    .ClassMap(() => new KeyValueMap());;

            MapCollection(o => o).ToElement("Obs", true)
                .Set(v => dataSet.Series[key].Add(v))
                .ClassMap(() => new ObservationMap(dataSet));
        }

        private IEnumerable<KeyValue> GetKeyValues(AttributeValueCollection attributes)
        {
            foreach (var attribute in attributes)
            {
                var value = new KeyValue() { Concept = attribute.Attribute.Concept.ID, Value = attribute.Value.ToString() };
                // TODO: implement startTime
                yield return value;
            }
        }

        protected override Series Return()
        {
            return _series;
        }

        protected override void AddAnnotation(Annotation annotation)
        {
            _series.Annotations.Add(annotation);
        }
    }
}
