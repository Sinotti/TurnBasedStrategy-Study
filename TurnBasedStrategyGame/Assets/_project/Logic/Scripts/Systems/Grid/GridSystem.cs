using UnityEngine;
// Gerencia a criação do Grid (tabela). Toda essa funcionalidade ocorre ao instanciar essa classe.
// As células em sí são coordenadas no mundo, os objetos em sí que
// representam a célula e armazenam os dados são os CellObjects
public class GridSystem
{
    private CellObject[,] _cellObjects; // Array bidimensional

    private int _horizontalCells;
    private int _verticalCells;
    private float _cellSize;

    // Constructor: Executa ao instanciar o objeto. (Só posso usar sem Monobehavior).
    public GridSystem(int horizontalCells, int verticalCells, float cellSize) 
    {
        _horizontalCells = horizontalCells;
        _verticalCells = verticalCells;
        _cellSize = cellSize;

        // Inicializa o Array com a quantia de células do grid (tabela), pois cada celula vai ter seu objeto
        _cellObjects = new CellObject[horizontalCells, verticalCells]; 

        for(int x = 0; x < horizontalCells; x++) // Percorre as posições das celulas no grid
        {
            for(int z = 0; z < verticalCells; z++) 
            {
                CellPosition currentCellPosition =  new CellPosition(x, z); // Armazena a posição da célula dentro do grid
                // Cria um novo CellObject que corresponde as coordenadas da célula no grid
                _cellObjects[x,z] = new CellObject(this, currentCellPosition);  
            }
        }
    }

    public Vector3 GetCellWorldPos(CellPosition cellPosition) 
    {
        return new Vector3(cellPosition.x, 0, cellPosition.z) * _cellSize;
    }

    public CellPosition GetCellGridPos(Vector3 worldPosition) 
    {
        return new CellPosition(Mathf.RoundToInt(worldPosition.x / _cellSize), Mathf.RoundToInt(worldPosition.z / _cellSize));
    } 

    public void CreateDebugCellObjects(GameObject debugPrefab)
    {
        for (int x = 0; x < _horizontalCells; x++)
        {
            for (int z = 0; z < _verticalCells; z++)
            {
                CellPosition currentCellPosition = new CellPosition(x, z); // Salva a posição da célula atual

                GameObject debugObject = GameObject.Instantiate(debugPrefab, GetCellWorldPos(currentCellPosition), Quaternion.identity);
                CellDebugObject cellDebugObject = debugObject.GetComponent<CellDebugObject>();

                cellDebugObject.SetDebugCellPos(GetCellObject(currentCellPosition));
            }
        }
    }

    // Entra a posição da celula no grid e saí o CellObject da célula em questão
    public CellObject GetCellObject(CellPosition cellPosition) 
    {
        return _cellObjects[cellPosition.x, cellPosition.z];
    }
}
