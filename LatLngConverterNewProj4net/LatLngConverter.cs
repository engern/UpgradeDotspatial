using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using LatLngConverterNewProj4net.Model;

namespace LatLngConverterNewProj4net
{
    public class LatLngConverter
    {
        public static LatLngPoint ConvertUTM33ToLatLon(double north, double east)
        {
            var csFactory = new CoordinateSystemFactory();
            var utm33 = ProjectedCoordinateSystem.WGS84_UTM(33, true);
            var wgs84 = GeographicCoordinateSystem.WGS84;

            var transform = new CoordinateTransformationFactory().CreateFromCoordinateSystems(utm33, wgs84);

            var point = transform.MathTransform.Transform([east, north]);

            return new LatLngPoint
            {
                Lat = point[1],
                Lng = point[0]
            };
        }

        public static LatLngPoint ConvertUTM33ToLatLonFromWKT(double north, double east)
        {
            var csFactory = new CoordinateSystemFactory();
            var utm33 = csFactory.CreateFromWkt("PROJCS[\"EPSG:25833\",GEOGCS[\"\",DATUM[\"\",SPHEROID[\"GRS_1980\",6378137,298.257222101004]],PRIMEM[\"Greenwich\",0],UNIT[\"Degree\",0.0174532925199433]], PROJECTION[\"Transverse_Mercator\"],PARAMETER[\"False_Easting\",500000],PARAMETER[\"False_Northing\",0],PARAMETER[\"Central_Meridian\",15],PARAMETER[\"Scale_Factor\",0.9996],UNIT[\"Meter\",1]]");
            var wgs84 = GeographicCoordinateSystem.WGS84;

            var transform = new CoordinateTransformationFactory().CreateFromCoordinateSystems(utm33, wgs84);

            var point = transform.MathTransform.Transform([east, north]);

            return new LatLngPoint
            {
                Lat = point[1],
                Lng = point[0]
            };
        }
    }
}