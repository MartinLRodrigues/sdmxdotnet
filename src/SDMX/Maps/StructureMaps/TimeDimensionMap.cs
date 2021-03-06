using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Common;
using OXM;

namespace SDMX.Parsers
{
    internal class TimeDimensionMap : ComponentMap<TimeDimension>
    {
        TimeDimension _timeDimension;
        Concept _concept;

        public TimeDimensionMap(StructureMessage message)
            : base(message)
        {
            AttributesOrder("conceptRef",
                            "codelist",
                            "crossSectionalAttachmentLevel");

            ElementsOrder("TextFormat", "Annotations");

            Map(o => o.CrossSectionalAttachmentLevel).ToAttributeGroup("crossSectionalAttachmentLevel", CrossSectionalAttachmentLevel.None)
               .Set(v => _timeDimension.CrossSectionalAttachmentLevel = v)
               .GroupTypeMap(new CrossSectionalAttachmentLevelMap());

        }

        protected override TimeDimension Create(Concept concept)
        {
            _concept = concept;
            if (concept != null)
            {
                _timeDimension = new TimeDimension(concept);
            }
            else
            {
                var fakeConcept = CreateFakeConcept();
                _timeDimension = new TimeDimension(fakeConcept);
            }

            return _timeDimension;
        }

        protected override void AddAnnotation(Annotation annotation)
        {
            _timeDimension.Annotations.Add(annotation);
        }

        protected override TimeDimension Return()
        {
            if (_timeDimension.CodeList == null && _timeDimension.TextFormat == null)
            {
                _timeDimension.TextFormat = new TimePeriodTextFormat();
            }

            if (_concept == null)
            {
                return null;
            }
            else
            {
                return _timeDimension;
            }
        }
    }
}
