using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] TowerScript tower;
    [SerializeField] int _maxTowerNumber = 5;
    [SerializeField] Transform _towerParentTransform;

    private Queue<TowerScript> _towerStack = new Queue<TowerScript>(5);
    private Waypoint _firstTowerWaypoint;
    public void AddTower(Waypoint baseWaypoint)
    {
        if (_towerStack.Count < _maxTowerNumber)
        {
            AddNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    void AddNewTower(Waypoint baseWaypoint)
    {
        var _newTower = Instantiate(tower, baseWaypoint.transform.position, Quaternion.identity);
        _newTower.transform.parent = _towerParentTransform;

        _newTower.baseWaypoint = baseWaypoint;
        baseWaypoint._towerSet = true;
        _towerStack.Enqueue(_newTower);     
    }

    public void MoveExistingTower(Waypoint waypoint)
    {
        
        var casheTower = _towerStack.Dequeue();
        casheTower.baseWaypoint._towerSet = false;
        
        waypoint._towerSet = true;
        casheTower.transform.position = waypoint.transform.position;
        casheTower.baseWaypoint = waypoint;
        _towerStack.Enqueue(casheTower);
    }
}
