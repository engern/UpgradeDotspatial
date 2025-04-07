using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using RegObs.GeoCode.Models;

namespace RegObs.GeoCode.Converters
{
    public class LatLngConverter
    {
        // ETRS89 / UTM zone 33N
        // Most NVE map services uses this as the default sr
        private const int ETRS89_UTM_Z33 = 25833;

        public static UTMPoint ConvertLatLonToUTM33(double lat, double lng)
        {
            var wgs84 = GeographicCoordinateSystem.WGS84;
            var utm33 = ProjectedCoordinateSystem.WGS84_UTM(33, true);

            var transform = new CoordinateTransformationFactory().CreateFromCoordinateSystems(utm33, wgs84);

            var point = transform.MathTransform.Transform([lng, lat]);

            return new UTMPoint
            {
                North = (int)point[1],
                East = (int)point[0],
                Zone = 33,
                Wkid = ETRS89_UTM_Z33
            };
        }

        public static LatLngPoint ConvertUTM33ToLatLon(double north, double east)
        {
            var coordinateSystemFactory = new CoordinateSystemFactory();

            //Defines the starting coordiante system
            var utm33 = ProjectedCoordinateSystem.WGS84_UTM(33, true);

            //Defines the ending coordiante system
            var wgs84 = GeographicCoordinateSystem.WGS84;

            var transform = new CoordinateTransformationFactory().CreateFromCoordinateSystems(utm33, wgs84);
            var latLng = transform.MathTransform.Transform([east, north]);

            return new LatLngPoint
            {
                Lat = latLng[1],
                Lng = latLng[0]
            };
        }
    }
}
