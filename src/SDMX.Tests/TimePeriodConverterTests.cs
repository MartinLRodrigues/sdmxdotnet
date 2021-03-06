//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using NUnit.Framework;
//using System.Xml.Linq;
//using SDMX.Parsers;
//using System.Xml;
//using System.IO;
//using OXM;
//using System.Xml.Serialization;
//using System.Text.RegularExpressions;

//namespace SDMX.Tests
//{
//    [TestFixture]
//    public class TimePeriodConverterTests
//    {
//        [Test]
//        public void DateTimeTimePeriod()
//        {
//            var converter = new TimePeriodConverter();

//            string value = "2001-10-26T21:32:52+02:00";
//            var time = converter.ToObj(value);
//            Assert.AreEqual(value, converter.ToXml(time));

//            value = "2001-10-26T21:32:52";
//            time = converter.ToObj(value);
//            Assert.AreEqual(value, converter.ToXml(time));

//            value = "2001-10-26T19:32:52Z";
//            time = converter.ToObj(value);
//            Assert.AreEqual("2001-10-26T19:32:52", converter.ToXml(time));

//            value = "2001-10-26T19:32:52+00:00";
//            time = converter.ToObj(value);
//            Assert.AreEqual("2001-10-26T19:32:52", converter.ToXml(time));

//            value = "2001-10-26T21:32:52.126";
//            time = converter.ToObj(value);
//            Assert.AreEqual(value, converter.ToXml(time));
//        }

//        [Test]
//        public void DateTimePeriod()
//        {
//            var converter = new TimePeriodConverter();

//            string value = "2001-10-16+02:00";
//            var time = converter.ToObj(value);
//            Assert.AreEqual("2001-10-16+02:00", converter.ToXml(time));

//            value = "2001-10-26Z";
//            time = converter.ToObj(value);
//            Assert.AreEqual("2001-10-26", converter.ToXml(time));


//            value = "2001-10-26+00:00";
//            time = converter.ToObj(value);
//            Assert.AreEqual("2001-10-26", converter.ToXml(time));

//            value = "2001-10-26";
//            time = converter.ToObj(value);
//            Assert.AreEqual("2001-10-26", converter.ToXml(time));
//        }

//        [Test]
//        public void YearMonthTimePeriod()
//        {
//            var converter = new TimePeriodConverter();

//            string value = "2001-10+02:00";
//            var time = converter.ToObj(value);
//            Assert.AreEqual("2001-10+02:00", converter.ToXml(time));

//            value = "2001-10Z";
//            time = converter.ToObj(value);
//            Assert.AreEqual("2001-10", converter.ToXml(time));

//            value = "2001-10+00:00";
//            time = converter.ToObj(value);
//            Assert.AreEqual("2001-10", converter.ToXml(time));

//            value = "2001-10";
//            time = converter.ToObj(value);
//            Assert.AreEqual("2001-10", converter.ToXml(time));
//        }

//        [Test]
//        public void YearTimePeriod()
//        {
//            var converter = new TimePeriodConverter();

//            string value = "2001+02:00";            
//            var time = converter.ToObj(value);
//            Assert.AreEqual(value, converter.ToXml(time));

//            value = "2001Z";
//            time = converter.ToObj(value);
//            Assert.AreEqual("2001", converter.ToXml(time));

//            value = "2001+00:00";
//            time = converter.ToObj(value);
//            Assert.AreEqual("2001", converter.ToXml(time));

//            value = "2001";
//            time = converter.ToObj(value);
//            Assert.AreEqual("2001", converter.ToXml(time));
//        }

//        [Test]
//        public void WeeklyTimePeriod()
//        {
//            var converter = new TimePeriodConverter();

//            string value = "2001-W2";
//            var time = converter.ToObj(value);
//            Assert.AreEqual(value, converter.ToXml(time));

//            value = "1999-W51";
//            time = converter.ToObj(value);
//            Assert.AreEqual(value, converter.ToXml(time));
//        }

//        [Test]
//        public void QuarterTimePeriod()
//        {
//            var converter = new TimePeriodConverter();

//            string value = "2001-Q1";
//            var time = converter.ToObj(value);
//            Assert.AreEqual(value, converter.ToXml(time));

//            value = "1999-Q3";
//            time = converter.ToObj(value);
//            Assert.AreEqual(value, converter.ToXml(time));
//        }

//        [Test]
//        public void BiannualTimePeriod()
//        {
//            var converter = new TimePeriodConverter();

//            string value = "2001-B1";
//            var time = converter.ToObj(value);
//            Assert.AreEqual(value, converter.ToXml(time));

//            value = "1999-B2";
//            time = converter.ToObj(value);
//            Assert.AreEqual(value, converter.ToXml(time));
//        }

//        [Test]
//        public void TriannualTimePeriod()
//        {
//            var converter = new TimePeriodConverter();

//            string value = "2001-T1";
//            var time = converter.ToObj(value);
//            Assert.AreEqual(value, converter.ToXml(time));

//            value = "1999-T2";
//            time = converter.ToObj(value);
//            Assert.AreEqual(value, converter.ToXml(time));
//        }
//    }
//}
