using UnityEngine;

public class GhostScatter : GhostBehavior
{
    private void OnDisable()
    {
        ghost.chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        // nieko nedaryk kai ghostas yra frightened
        if (node != null && enabled && !ghost.frightened.enabled)
        {
            // pasirink random direction
            int index = Random.Range(0, node.availableDirections.Count);

            // kad negrizti is tos kripties is kurios atejo padidina indeksa iki kitos galimos krypties
            if (node.availableDirections.Count > 1 && node.availableDirections[index] == -ghost.movement.direction)
            {
                index++;

                // Jei indeksas perpildytas graziname atgal
                if (index >= node.availableDirections.Count) {
                    index = 0;
                }
            }

            ghost.movement.SetDirection(node.availableDirections[index]);
        }
    }

}
