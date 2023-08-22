//using OpenCvSharp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Wpf3DApp.Math
//{
//    internal class DimensionResolver
//    {
//        public static void AlignEyeModel(
//            Point3f[] modelPoints,
//            Point2f[] imagePoints,
//            Size imageSize,
//            out Vec3d rotationEulerAngles,
//            out Vec3d translationVector)
//        {
//            // Assume some initial intrinsic parameters
//            double focalLength = imageSize.Width;
//            Point2d principalPoint = new Point2d(imageSize.Width / 2.0, imageSize.Height / 2.0);
//            Mat cameraMatrix = new Mat(3, 3, MatType.CV_64FC1, new double[]
//            {
//            focalLength, 0, principalPoint.X,
//            0, focalLength, principalPoint.Y,
//            0, 0, 1
//            });

//            // Assume no lens distortion
//            Mat distCoeffs = new Mat(1, 4, MatType.CV_64FC1, new double[] { 0, 0, 0, 0 });

//            // Solve the PnP problem to get rotation and translation vectors
//            Cv2.SolvePnP(
//                modelPoints,
//                imagePoints,
//                cameraMatrix,
//                distCoeffs,
//                out var rotationVector,
//                out translationVector);

//            // Convert rotation vector to rotation matrix
//            Mat rotationMatrix = new Mat();
//            Cv2.Rodrigues(rotationVector, rotationMatrix);

//            // Convert rotation matrix to Euler angles
//            rotationEulerAngles = RotationMatrixToEulerAngles(rotationMatrix);
//        }

//        public static Vec3d RotationMatrixToEulerAngles(Mat R)
//        {
//            // ... Implementation to convert a 3x3 rotation matrix
//            // to Euler angles (roll, pitch, yaw) ...
//            // This function would involve some trigonometry.

//            // Placeholder for actual implementation
//            return new Vec3d(0, 0, 0);
//        }

//        public static Vec3d RotationMatrixToEulerAngles(Mat R)
//        {
//            double sy = Math.Sqrt(R.At<double>(0, 0) * R.At<double>(0, 0) + R.At<double>(1, 0) * R.At<double>(1, 0));

//            bool singular = sy < 1e-6;

//            double x, y, z;

//            if (!singular)
//            {
//                x = Math.Atan2(R.At<double>(2, 1), R.At<double>(2, 2));
//                y = Math.Atan2(-R.At<double>(2, 0), sy);
//                z = Math.Atan2(R.At<double>(1, 0), R.At<double>(0, 0));
//            }
//            else
//            {
//                x = Math.Atan2(-R.At<double>(1, 2), R.At<double>(1, 1));
//                y = Math.Atan2(-R.At<double>(2, 0), sy);
//                z = 0;
//            }

//            // Return Euler angles in degrees
//            return new Vec3d(x * (180.0 / Math.PI), y * (180.0 / Math.PI), z * (180.0 / Math.PI));
//        }
//        public void Main()
//        {
//            // Define corresponding points between 3D eye model and 2D image
//            Point3f[] modelPoints = new Point3f[]
//            {
//            new Point3f(0, 0, 0),    // Center of pupil
//                                     // ... additional points ...
//            };

//            Point2f[] imagePoints = new Point2f[]
//            {
//            new Point2f(320, 240),   // Center of pupil in image
//                                     // ... additional points ...
//            };

//            // Define image size
//            Size imageSize = new Size(640, 480);

//            // Align 3D eye model with 2D image
//            EyeAlignment.AlignEyeModel(modelPoints, imagePoints, imageSize, out Vec3d rotationEulerAngles, out Vec3d translationVector);

//            // Print the results
//            Console.WriteLine("Rotation Angles (Roll, Pitch, Yaw): " + rotationEulerAngles);
//            Console.WriteLine("Translation Vector: " + translationVector);
//        }

//    }
//}
