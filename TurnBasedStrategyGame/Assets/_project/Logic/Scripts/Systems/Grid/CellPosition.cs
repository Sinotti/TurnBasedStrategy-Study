using System;
using Unity.VisualScripting;

public struct CellPosition : IEquatable<CellPosition>
{
    public int x;
    public int z;

    public CellPosition(int x, int z)
    {
        this.x = x; 
        this.z = z;
    }

    public override string ToString()
    {
        return $" x: {x}; z: {z};";
    }

    // Overrides Equals e GetHashCode podem ser gerados pela própria IDE
    public override bool Equals(object obj) // Define como a igualdade deve ser verificada para instâncias de sua estrutura.
    {
        return obj is CellPosition position &&
               x == position.x &&
               z == position.z;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public bool Equals(CellPosition other)
    {
        return this == other;
    }

    // Permite usar os operadores " == " e " != ". Isso é necessário por ser uma Struct custom
    public static bool operator == (CellPosition a, CellPosition b) 
    {
        return a.x == b.x && a.z == b.z;
    }

    public static bool operator != (CellPosition a, CellPosition b) 
    {
        return !(a == b);
    }
}