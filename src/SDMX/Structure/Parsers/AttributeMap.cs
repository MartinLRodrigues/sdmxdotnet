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
    internal class AttributeMap : CompoenentMap<Attribute>
    {
        Attribute _attribute;

        public AttributeMap(DSD dsd)
            : base(dsd)
        {
            AttributesOrder("conceptRef",
                            "codelist",
                            "attachmentLevel",
                            "assignmentStatus",
                            "isTimeFormat",
                            "crossSectionalAttachmentLevel",
                            "isEntityAttribute",
                            "isNonObservationalTim",
                            "isCountAttribute",
                            "isFrequencyAttribute",
                            "isIdentityAttribute");

            ElementsOrder("TextFormat", "AttachmentGroup", "AttachmentMeasure", "Annotations");

            Map(o => o.AttachementLevel).ToAttribute("attachmentLevel", true)
                .Set(v => _attribute.AttachementLevel = v)
                .Converter(new EnumConverter<AttachmentLevel>());

            Map(o => o.AssignmentStatus).ToAttribute("assignmentStatus", true)
                .Set(v => _attribute.AssignmentStatus = v)
                .Converter(new EnumConverter<AssignmentStatus>());

            Map(o => o.IsTimeFormat).ToAttribute("isTimeFormat", false, "false")
                .Set(v => _attribute.IsTimeFormat = v)
                .Converter(new BooleanConverter());

            Map(o => o.IsEntityAttribute).ToAttribute("isEntityAttribute", false, "false")
                .Set(v => _attribute.IsEntityAttribute = v)
                .Converter(new BooleanConverter());

            Map(o => o.IsNonObservationalTimeAttribute).ToAttribute("isNonObservationalTimeAttribute", false, "false")
                .Set(v => _attribute.IsNonObservationalTimeAttribute = v)
                .Converter(new BooleanConverter());

            Map(o => o.IsCountAttribute).ToAttribute("isCountAttribute", false, "false")
                .Set(v => _attribute.IsCountAttribute = v)
                .Converter(new BooleanConverter());

            Map(o => o.IsFrequencyAttribute).ToAttribute("IsFrequencyAttribute", false, "false")
                .Set(v => _attribute.IsFrequencyAttribute = v)
                .Converter(new BooleanConverter());

            Map(o => o.IsIdentityAttribute).ToAttribute("isIdentityAttribute", false, "false")
               .Set(v => _attribute.IsIdentityAttribute = v)
               .Converter(new BooleanConverter());

            MapCollection(o => o.AttachmentGroups).ToSimpleElement("AttachmentGroup", false)
                .Set(v => v.ForEach(i => _attribute.AttachmentGroups.Add(i)))
                .Converter(new IDConverter());

            MapCollection(o => o.AttachmentMeasures).ToSimpleElement("AttachmentMeasure", false)
                .Set(v => v.ForEach(i => _attribute.AttachmentMeasures.Add(i)))
                .Converter(new IDConverter());
        }      


        protected override Attribute Create(Concept conecpt)
        {
            _attribute = new Attribute(conecpt);
            return _attribute;
        }

        protected override void SetAnnotations(IEnumerable<Annotation> annotations)
        {
            annotations.ForEach(i => _attribute.Annotations.Add(i));
        }

        protected override Attribute Return()
        {
            return _attribute;
        }
    }
}
