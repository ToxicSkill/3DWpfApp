using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Wpf3DApp.Models
{
    public class SphereGeometry3D : RoundMesh3D
    {
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

        protected override void CalculateGeometry()
        {
            points = new Point3DCollection();
            triangleIndices = new Int32Collection();

           var sphere = GenerateSphere(new Point3D(), r, 360, 100);

            points = sphere.Positions;
            triangleIndices = sphere.TriangleIndices;
        }

        public SphereGeometry3D()
        { }
    }
}