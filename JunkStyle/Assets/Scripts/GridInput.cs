using UnityEngine;

public class GridInput : MonoBehaviour
{
    [SerializeField]
    private Grid grid;

    [SerializeField]
    private GameObject cellIndicator;

    private Vector3 lastPosition;

    private void Update()
    {
        Vector3Int gridPosition = grid.WorldToCell(MousePosition());
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }

    private Vector3 MousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Cursor.visible = false;
            lastPosition = hit.point;
        }
        else
        {
            Cursor.visible = true;
            lastPosition = Vector3.down;
        }

        return lastPosition;
    }
}
