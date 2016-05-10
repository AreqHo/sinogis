using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace HRQ.Utils {
	public static class Utils {
        const string path = "HRQ.Images.";

		public static string GetRelativePath(string name) {
			name = "Data\\" + name;
			string path = System.Windows.Forms.Application.StartupPath;
			string s = "\\";
			for (int i = 0 ; i <= 10 ; i++) {
				if (System.IO.File.Exists(path + s + name))
					return (path + s + name);
				else 
					s += "..\\";
			} 
			path = Environment.CurrentDirectory;
			s = "\\";
			for (int i = 0 ; i <= 10 ; i++) {
				if (System.IO.File.Exists(path + s + name))
					return (path + s + name);
				else 
					s += "..\\";
			} 
			return "";
		}
		public static void SetConnectionString(System.Data.OleDb.OleDbConnection oleDbConnection, string path) {
			oleDbConnection.ConnectionString = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source={0};Mode=Share Deny None;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False", path);
		}
        public static Image GetImage(string name) {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path + name);
            if (stream != null)
                return Image.FromStream(stream);
            return null;
        }
        public static Cursor GetCursor(string name) {
            return ResourceImageHelper.CreateCursorFromResources(path + name, Assembly.GetExecutingAssembly());
        }
	}

    public static class PieExplodingHelper {
        static SeriesPointFilter CreateFilter(string mode) {
            return new SeriesPointFilter(SeriesPointKey.Argument, DataFilterCondition.Equal, mode);
        }
        static void ApplyFilterMode(PieSeriesViewBase view, string mode) {
            view.ExplodedPointsFilters.Clear();
            view.ExplodedPointsFilters.Add(CreateFilter(mode));
            view.ExplodeMode = PieExplodeMode.UseFilters;
        }

        public const string None = "None";
        public const string All = "All";
        public const string MinValue = "Min Value";
        public const string MaxValue = "Max Value";
        public const string Custom = "Custom";

        public static List<string> CreateModeList(SeriesPointCollection points, bool supportCustom) {
            List<string> list = new List<string>();
            list.Add(None);
            list.Add(All);
            list.Add(MinValue);
            list.Add(MaxValue);
            foreach (SeriesPoint point in points)
                list.Add(point.Argument);
            if (supportCustom)
                list.Add(Custom);
            return list;
        }
        public static void ApplyMode(PieSeriesViewBase view, string mode) {
            switch (mode) {
                case Custom:
                    break;
                case None:
                    view.ExplodeMode = PieExplodeMode.None;
                    break;
                case All:
                    view.ExplodeMode = PieExplodeMode.All;
                    break;
                case MinValue:
                    view.ExplodeMode = PieExplodeMode.MinValue;
                    break;
                case MaxValue:
                    view.ExplodeMode = PieExplodeMode.MaxValue;
                    break;
                default:
                    ApplyFilterMode(view, mode);
                    break;
            }
        }
    }

    public enum Gender {
        Male,
        Female
    }
    public static class PopulationAgeProvider {
        public static IList<AgePopulation> GetPopulationAgeStructure() {
            string[] countries = new string[] { "United States", "Brazil", "Russia", "Japan", "Mexico", "Germany", "United Kingdom" };
            string[] ageCategories = new string[] { "0-14 years", "15-64 years", "65 years and older" };

            Dictionary<Gender, Dictionary<string, double[]>> population = new Dictionary<Gender, Dictionary<string, double[]>>();

            Dictionary<string, double[]> males = new Dictionary<string, double[]>();
            males.Add(ageCategories[0], new double[] { 29.956, 25.607, 13.493, 9.575, 17.306, 6.679, 5.816 });
            males.Add(ageCategories[1], new double[] { 90.354, 55.793, 48.983, 43.363, 30.223, 28.638, 19.622 });
            males.Add(ageCategories[2], new double[] { 14.472, 3.727, 5.802, 9.024, 1.927, 5.133, 3.864 });
            population.Add(Gender.Male, males);
            Dictionary<string, double[]> females = new Dictionary<string, double[]>();
            females.Add(ageCategories[0], new double[] { 28.597, 24.67, 12.971, 9.105, 16.632, 6.333, 5.519 });
            females.Add(ageCategories[1], new double[] { 91.827, 57.598, 52.14, 42.98, 31.868, 27.693, 19.228 });
            females.Add(ageCategories[2], new double[] { 20.362, 5.462, 12.61, 12.501, 2.391, 8.318, 5.459 });
            population.Add(Gender.Female, females);

            List<AgePopulation> result = new List<AgePopulation>();
            foreach (Gender gender in System.Enum.GetValues(typeof(Gender)))
                foreach (string ageCatregory in ageCategories)
                    for (int i = 0; i < countries.Length; i++)
                        result.Add(new AgePopulation(countries[i], ageCatregory, gender, population[gender][ageCatregory][i]));
            return result;
        }
    }
    public class AgePopulation {
        string name;
        string age;
        Gender gender;
        double population;

        public string Name { get { return name; } }
        public string Age { get { return age; } }
        public Gender Gender { get { return gender; } }
        public string GenderAgeKey { get { return gender.ToString() + ": " + age; } }
        public string CountryAgeKey { get { return name + ": " + age; } }
        public string CountryGenderKey { get { return name + ": " + gender.ToString(); } }
        public double Population { get { return population; } }

        public AgePopulation(string name, string age, Gender gender, double population) {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.population = population;
        }
    }

    public abstract class ScatterFunctionCalculatorBase {
        const int archimedeanSpiralIndex = 0;
        const int polarRoseIndex = 1;
        const int polarFoliumIndex = 2;
        const int spiralIntervalsCount = 72;
        const int roseIntervalsCount = 288;
        const int foliumSegmentIntervalsCount = 30;

        const double roseParameter = 7.0 / 4.0;
        const double foliumDistanceLimit = 3.0;

        protected abstract double NormalizeAngle(double angle);
        protected abstract double ToRadian(double angle);
        protected abstract double FromDegrees(double angle);

        List<SeriesPoint> FilterPointsByRange(List<SeriesPoint> points, double min, double max) {
            List<SeriesPoint> resultPoints = new List<SeriesPoint>();
            foreach (SeriesPoint point in points) {
                double pointValue = point.Values[0];
                if (pointValue <= max && pointValue >= min)
                    resultPoints.Add(point);
            }
            return resultPoints;
        }
        void CreatePolarFunctionPoints(double minAngleDegree, double maxAngleDegree, int intervalsCount, Func<double, double> function, List<SeriesPoint> points) {
            double minAngle = FromDegrees(minAngleDegree);
            double maxAngle = FromDegrees(maxAngleDegree);
            double angleStep = (maxAngle - minAngle) / (double)intervalsCount;
            for (int pointIndex = 0; pointIndex <= intervalsCount; pointIndex++) {
                double angle = minAngle + pointIndex * angleStep;
                double angleRadians = ToRadian(angle);
                double distance = function(angleRadians);
                double normalAngle = NormalizeAngle(angle);
                points.Add(new SeriesPoint(normalAngle, distance));
            }
        }
        double ArchimedeanSpiralFunction(double angleRadians) {
            return angleRadians;
        }
        double PolarRoseFunction(double angleRadians) {
            return Math.Max(0.0, Math.Sin(roseParameter * angleRadians));
        }
        double PolarFoliumFunction(double angleRadians) {
            double sin = Math.Sin(angleRadians);
            double cos = Math.Cos(angleRadians);
            return (3.0 * sin * cos)/ (Math.Pow(sin, 3.0) + Math.Pow(cos, 3.0));
        }

        public SeriesPoint[] GenerateScatterFunctionPoints(int index) {
            List<SeriesPoint> points = new List<SeriesPoint>();
            switch (index) {
                case archimedeanSpiralIndex:
                    CreatePolarFunctionPoints(0.0, 720.0, spiralIntervalsCount, ArchimedeanSpiralFunction, points);
                    break;
                case polarRoseIndex:
                    CreatePolarFunctionPoints(0.0, 1440.0, roseIntervalsCount, PolarRoseFunction, points);
                    break;
                case polarFoliumIndex:
                    CreatePolarFunctionPoints(120.0, 180.0, foliumSegmentIntervalsCount, PolarFoliumFunction, points);
                    CreatePolarFunctionPoints(0.0, 90.0, foliumSegmentIntervalsCount, PolarFoliumFunction, points);
                    CreatePolarFunctionPoints(270.0, 330.0, foliumSegmentIntervalsCount, PolarFoliumFunction, points);
                    points = FilterPointsByRange(points, 0.0, foliumDistanceLimit);
                    break;
            }
            return points.ToArray();
        }
    }

    public class RadianScatterFunctionCalculator : ScatterFunctionCalculatorBase {
        protected override double NormalizeAngle(double angle) {
            return angle % (Math.PI * 2.0);
        }
        protected override double ToRadian(double angle) {
            return angle;
        }
        protected override double FromDegrees(double angle) {
            return angle * Math.PI / 180.0;
        }
    }

    public class DegreeScatterFunctionCalculator : ScatterFunctionCalculatorBase {
        protected override double NormalizeAngle(double angle) {
            return angle % 360;
        }
        protected override double ToRadian(double angle) {
            return angle * Math.PI / 180.0;
        }
        protected override double FromDegrees(double angle) {
            return angle;
        }
    }
}
