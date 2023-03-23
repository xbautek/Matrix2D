using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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

        
    }
}
