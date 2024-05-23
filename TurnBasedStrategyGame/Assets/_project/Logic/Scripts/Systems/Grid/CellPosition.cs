public struct CellPosition
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
}