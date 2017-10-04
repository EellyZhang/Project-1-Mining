using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2GameController : MonoBehaviour
{
	int bronzePlayer;
	int silverPlayer;
	public int bronzeSupply;
	public int silverSupply;
	public int miningSpeed;
	int timeToMine;
	public GameObject cubePrefab;

	float xPosition;
	Vector3 cubePosition;
	GameObject currentCube;

	// Use this for initialization
	void Start()
	{

		bronzePlayer = 0;
		silverPlayer = 0;
		miningSpeed = 3;
		bronzeSupply = 3;
		silverSupply = 2;
		timeToMine = miningSpeed;

		xPosition = 0f;

	}

	// Update is called once per frame
	void Update()
	{
		if (bronzePlayer < 3 || silverPlayer < 2)
		{

			if (Time.time > timeToMine)
			{

				if (bronzeSupply >= 1)
				{
					currentCube = Instantiate(cubePrefab, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity);
					currentCube.GetComponent<Renderer>().material.color = Color.red;

					bronzePlayer += 1;
					bronzeSupply -= 1;
				}

				else if (bronzeSupply == 0 && silverSupply >= 1)
				{
					currentCube = Instantiate(cubePrefab, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity);
					currentCube.GetComponent<Renderer>().material.color = Color.white;

					silverPlayer += 1;
					silverSupply -= 1;
				}

				print("Bronze: " + bronzePlayer + "Silver: " + silverPlayer);

				timeToMine += miningSpeed;
			}
		}
	}
}