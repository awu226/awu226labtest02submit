using UnityEngine;
using Pathfinding.Serialization.JsonFx; 

public class Sketch : MonoBehaviour {
	public GameObject myPrefab;
	public Material material1;  
	public Material material2; 
	public Material material3; 
	public Material material4; 
	public GameObject cube;

	private string readingID;
	private string location;
	private string ecologicalValue;
	private string HistoricalSignificance;
	private string whenReadingRecorded;
	private float x;
	private float y;
	private float z;
	public string jsonResponse;
	public string _WebsiteURL = "http://awu226.azurewebsites.net/tables/TreeSurvey?zumo-api-version=2.0.0";

	void Start () {

		//defining, on top to make it public
	jsonResponse = Request.GET(_WebsiteURL);


		if (string.IsNullOrEmpty(jsonResponse))
		{
			return;
		}


		TreeSurvey[] treesurveys = JsonReader.Deserialize<TreeSurvey[]>(jsonResponse);

		foreach (TreeSurvey treesurvey in treesurveys)
		{

			Debug.Log("X is " + treesurvey.X + ", Y is " + treesurvey.Y + ", Z is " + treesurvey.Z + "" ) ;
			readingID = treesurvey.TreeID;
			location = treesurvey.Location;
			ecologicalValue = treesurvey.EcologicalValue;
			HistoricalSignificance= treesurvey.HistoricSignificance;
			whenReadingRecorded = treesurvey.WhenReadingRecorded;
			x = float.Parse(treesurvey.X);
			y = float.Parse(treesurvey.Y);
			z = float.Parse(treesurvey.Z);

			GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
			newCube.name = treesurvey.TreeID;			
			//label
			newCube.GetComponentInChildren<TextMesh> ().text= "(" + treesurvey.X + ", " + treesurvey.Y + ", " + treesurvey.Z + ")";
			//changes color e.g. data which are very high is changed to material1 colour, low is material2, anything else is material 3
			if (treesurvey.EcologicalValue == "Very High") {
				newCube.GetComponent<Renderer> ().material = material1;

			} else if (treesurvey.EcologicalValue == "Low") {
				newCube.GetComponent<Renderer> ().material = material2;

			} else {

				newCube.GetComponent<Renderer> ().material = material3;

			}
		
		}


	}

	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hitdata = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hitdata, 100)) {
				//change sphere colour when on click (material 1 is normal, will change to material4)
				hitdata.collider.gameObject.GetComponent<Renderer> ().material = material4;
				Debug.Log (hitdata.collider.name);
				int index = int.Parse(hitdata.collider.gameObject.name);

				TreeSurvey[] treesurveys = JsonReader.Deserialize<TreeSurvey[]>(jsonResponse);
				GameObject newCube = (GameObject)Instantiate(cube, new Vector3(hitdata.point.x, hitdata.point.y, hitdata.point.z), Quaternion.identity);
				newCube.GetComponentInChildren<TextMesh> ().text= "(" + treesurveys[index-1].Location + ", " + treesurveys[index-1].Y + ", " + treesurveys[index-1].Z + ")";
			}

		}
	}
}


