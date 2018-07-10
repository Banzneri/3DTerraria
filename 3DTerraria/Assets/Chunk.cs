using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

    public Material cubeMaterial;
    public Block[,,] chunkData;

    IEnumerator BuildChunk(int sizeX, int sizeY, int sizeZ){

        chunkData = new Block[sizeX, sizeY, sizeZ];

        //Create blocks
        for(int z = 0; z < sizeZ; z++)
            for(int y = 0; y < sizeY; y++)
                for(int x = 0; x < sizeX; x++){
                    Vector3 pos = new Vector3(x,y,z);
                    if(Random.Range(0,100) < 50)
                        chunkData[x,y,z] = new Block(Block.BlockType.DIRT, pos,
                                                        this.gameObject, cubeMaterial);
                    else
                        chunkData[x,y,z] = new Block(Block.BlockType.AIR, pos,
                                                        this.gameObject, cubeMaterial);
                }
        //Draw blocks
        for(int z = 0; z < sizeZ; z++)
            for(int y = 0; y < sizeY; y++)
                for(int x = 0; x < sizeX; x++){
                    chunkData[x,y,z].Draw();
                }
        CombineQuads();
        yield return null;
    }

    void CombineQuads(){
        //Combine children meshes
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        for(int i = 0; i < meshFilters.Length; i++){
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }
        //Create mesh for parent object
        MeshFilter mf = (MeshFilter) this.gameObject.AddComponent(typeof(MeshFilter));
        mf.mesh = new Mesh();

        //Add combined meshes as the parent's mesh
        mf.mesh.CombineMeshes(combine);

        MeshRenderer renderer = this.gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material = cubeMaterial;

        //Delete quads
        foreach (Transform quad in this.transform) {
            Destroy(quad.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(BuildChunk(16,16,16));
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
