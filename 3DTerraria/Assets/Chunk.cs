﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk {

    public Material cubeMaterial;
    public Block[,,] chunkData;
    public GameObject chunk;

    void BuildChunk(){

        chunkData = new Block[World.chunkSize,World.chunkSize,World.chunkSize];

        //Create blocks
        for(int z = 0; z < World.chunkSize; z++)
            for(int y = 0; y < World.chunkSize; y++)
                for(int x = 0; x < World.chunkSize; x++){
                    Vector3 pos = new Vector3(x,y,z);
                    if(Random.Range(0,100) < 50)
                        chunkData[x,y,z] = new Block(Block.BlockType.DIRT, pos,
                                                        chunk.gameObject, this);
                    else
                        chunkData[x,y,z] = new Block(Block.BlockType.AIR, pos,
                                                        chunk.gameObject, this);
                }
    }

    public void DrawChunk(){
        for(int z = 0; z < World.chunkSize; z++)
            for(int y = 0; y < World.chunkSize; y++)
                for(int x = 0; x < World.chunkSize; x++){
                    chunkData[x,y,z].Draw();
                }
        CombineQuads();
    }

    public Chunk (Vector3 position, Material c){
        chunk = new GameObject(World.BuildChunkName(position));
        chunk.transform.position = position;
        cubeMaterial = c;
        BuildChunk();
    }

    void CombineQuads(){
        //Combine children meshes
        MeshFilter[] meshFilters = chunk.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        for(int i = 0; i < meshFilters.Length; i++){
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }
        //Create mesh for parent object
        MeshFilter mf = (MeshFilter) chunk.gameObject.AddComponent(typeof(MeshFilter));
        mf.mesh = new Mesh();

        //Add combined meshes as the parent's mesh
        mf.mesh.CombineMeshes(combine);

        MeshRenderer renderer = chunk.gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material = cubeMaterial;

        //Delete quads
        foreach (Transform quad in chunk.transform) {
            GameObject.Destroy(quad.gameObject);
        }
    }
}
