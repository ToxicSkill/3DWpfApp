using Wpf3DApp.ViewModels;
using Wpf.Ui.Common.Interfaces;
using System.Windows.Media.Media3D;
using System;
using System.Windows;
using System.Drawing;
using Point = System.Windows.Point;
using System.Windows.Media;
using OpenCvSharp;

namespace Wpf3DApp.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class ContentView : INavigableView<ContentViewModel>
    {
        public ContentViewModel ViewModel
        {
            get;
        }

        public ContentView(ContentViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            DataContext = ViewModel;
            GenerateImage();
            globeModel.Geometry = GenerateSphere(new Point3D(), 1, 360, 180); 
        } 
        MeshGeometry3D GenerateSphere(Point3D center, double radius,
                                    int slices, int stacks)
        {
            // Create the MeshGeometry3D.
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Fill the Position, Normals, and TextureCoordinates collections.
            for (int stack = 0; stack <= stacks; stack++)
            {
                double phi = Math.PI / 2 - stack * Math.PI / stacks;

                for (int slice = 0; slice <= slices; slice++)
                {
                    double theta = slice * 2 * Math.PI / slices;

                    Vector3D normal = (Vector3D)SphericalToCartesian(phi, theta, radius);
                    mesh.Normals.Add(normal);
                    mesh.Positions.Add(normal + center);
                    mesh.TextureCoordinates.Add(
                            new Point((double)slice / slices,
                                      (double)stack / stacks));
                }
            }

            // Fill the TriangleIndices collection.
            for (int stack = 0; stack < stacks; stack++)
                for (int slice = 0; slice < slices; slice++)
                {
                    int n = slices + 1; // Keep the line length down.

                    if (stack != 0)
                    {
                        mesh.TriangleIndices.Add((stack + 0) * n + slice);
                        mesh.TriangleIndices.Add((stack + 1) * n + slice);
                        mesh.TriangleIndices.Add((stack + 0) * n + slice + 1);
                    }
                    if (stack != stacks - 1)
                    {
                        mesh.TriangleIndices.Add((stack + 0) * n + slice + 1);
                        mesh.TriangleIndices.Add((stack + 1) * n + slice);
                        mesh.TriangleIndices.Add((stack + 1) * n + slice + 1);
                    }
                }
            return mesh;
        }

        Point3D SphericalToCartesian(double phi, double theta, double radius)
        {
            double y = radius * Math.Sin(phi);
            double scale = -radius * Math.Cos(phi);
            double x = scale * Math.Sin(theta);
            double z = scale * Math.Cos(theta);

            return new Point3D(x, y, z);
        }

        private void GenerateImage()
        {
            using var mat = new Mat(new OpenCvSharp.Size(1400, 670), MatType.CV_8UC3, new Scalar(205, 213, 220));
            using var center =  Cv2.ImRead("Images\\eye.jpg");
            var centerX = center.Width / 2;
            var centerY = center.Height / 2;
            var min = Math.Min(centerX, centerY);
            var X = centerX - min;
            var Y = centerY - min;
            using var centerCut = new Mat(center, new OpenCvSharp.Rect(X, Y, 2 * min, 2 * min));
            Cv2.Resize(centerCut, centerCut, new OpenCvSharp.Size(centerCut.Width / 4, centerCut.Height / 4));
            var x = mat.Width / 2 - centerCut.Width / 2;
            var y = mat.Height / 2 - centerCut.Height / 2;
            var matRoi = new Mat(mat, new OpenCvSharp.Rect(x, y, centerCut.Width, centerCut.Height));
            centerCut.CopyTo(matRoi);
            Cv2.ImWrite("Images\\generated.png", mat);
        }
    }
}
