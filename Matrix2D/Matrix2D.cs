using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Matrix2D
{
    public struct Matrix2D : IEquatable<Matrix2D>
    {
        public readonly int A { get; }
        public readonly int B { get; }
        public readonly int C { get; }
        public readonly int D { get; }

        public static Matrix2D Id { get; } = new Matrix2D();

        public Matrix2D(int a, int b, int c, int d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public Matrix2D() : this(1, 0, 0, 1) { }

        public override string ToString() => $"[[{A}, {B}], [{C}, {D}]]";



        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return base.Equals(obj);
        }



        public override int GetHashCode()
        {
            return HashCode.Combine(A, B, C, D);
        }

        public bool Equals(Matrix2D other)
        {
            if (this.A == other.A && this.B == other.B && this.C == other.C && this.D == other.D)
                return true;
            else return false;
        }

        public static bool operator ==(Matrix2D left, Matrix2D right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Matrix2D left, Matrix2D right)
        {
            return !(left == right);
        }

        public static Matrix2D operator +(Matrix2D left, Matrix2D right)
        {
            return new(left.A + right.A, left.B + right.B, left.C + right.C, left.D + right.D);
        }

        public static Matrix2D operator -(Matrix2D left, Matrix2D right)
        {
            return new(left.A - right.A, left.B - right.B, left.C - right.C, left.D - right.D);
        }



        public static Matrix2D operator *(Matrix2D left, int X)
        {
            return new(left.A * X, left.B * X, left.C * X, left.D * X);
        }

        public static Matrix2D operator *(int X, Matrix2D left)
        {
            return new(left.A * X, left.B * X, left.C * X, left.D * X);
        }

        public static Matrix2D operator -(Matrix2D left)
        {
            return new(left.A*(-1), left.B * (-1), left.C * (-1), left.D * (-1));
        }

        public static Matrix2D Transpose(Matrix2D matrix)
        {

            return new(matrix.A, matrix.C, matrix.B, matrix.D);
        }

        public static int Determinant(Matrix2D matrix)
        {
            return ((matrix.A*matrix.D) - (matrix.C*matrix.B));
        }

        public void Det()
        {
            Console.WriteLine(((A * D) - (C * B)));
        }

        public static explicit operator Matrix2D(int[,] matrix)
        {
            if(matrix == null)  throw new ArgumentException("null");

            if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2) throw new ArgumentException("zly rozmiar");

            return new Matrix2D(matrix[0, 0], matrix[0, 1], matrix[1, 0], matrix[1, 1]);
        }

        public static explicit operator int[,](Matrix2D matrix)
        {
            return new int [2,2] { { matrix.A, matrix.B }, { matrix.C, matrix.D } };
        }

        // 2 4 7 9


        ///<summary>
        ///Format example ----> Matrix.Parse("[[23,2],[31,773]]")
        ///</summary>
        public static Matrix2D Parse(string s)
        {
            int count = 1;

            foreach (char charek in s)
            {
                //             Matrix2D s = Matrix2D.Parse("[[2,2],[3,3]]");

                if (!char.IsDigit(charek))
                {
                    if(count>9)
                        throw new ArgumentException("zle cos dales taki format ma byc: [[2, 1],[3, 2]]");

                    if (count == 1 || count == 2 || count == 6)
                    {
                        if(!(charek == '['))
                        throw new ArgumentException("zle cos dales taki format ma byc: [[2, 1],[3, 2]]");
                        else
                        {
                            count++;
                            continue;
                        }
                    }

                    if (count == 4 || count == 8 || count == 9)
                    {
                        if (!(charek == ']'))
                            throw new ArgumentException("zle cos dales taki format ma byc: [[2, 1],[3, 2]]");
                        else
                        {
                            count++;
                            continue;
                        }
                    }
                    if (count == 3 || count == 5 || count == 7)
                    {
                        if (!(charek == ','))
                            throw new ArgumentException("zle cos dales taki format ma byc: [[2, 1],[3, 2]]");
                        else
                        {
                            count++;
                            continue;
                        }
                    }
                }
            }
            string rest ="";
            for(int i = 0; i<s.Length; i++)
            {
                if (char.IsDigit(s[i]) || (s[i]) == ',')
                {
                    rest += s[i];
                }
            }

            
            

            int[] x = rest.Split(',').Select(int.Parse).ToArray();




            if (x.Length != 4)
            {
                throw new ArgumentException("zle cos dales taki format ma byc: [[2, 1],[3, 2]]");
            }

            return new(x[0], x[1], x[2], x[3]);
        }
    }
}
