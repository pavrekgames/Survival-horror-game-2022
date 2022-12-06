using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSurface : MonoBehaviour {

	private static float[] getTexturesMix (Vector3 playerPosition){

		Terrain terrain = Terrain.activeTerrain;
		TerrainData terrainData = terrain.terrainData;

		Vector3 terrainPosition = terrain.transform.position;

		int mapX = (int)(((playerPosition.x - terrainPosition.x) / terrainData.size.x) * terrainData.alphamapWidth);
		int mapZ = (int)(((playerPosition.z - terrainPosition.z) / terrainData.size.z) * terrainData.alphamapHeight);

		float[,,] splatMapData = terrainData.GetAlphamaps(mapX, mapZ, 1, 1);

		float[] targetMix = new float[splatMapData.GetUpperBound(2) + 1];

		for(int n = 0; n < targetMix.Length; ++n){
			targetMix[n] = splatMapData[0, 0, n];
		}

		return targetMix;
	}

	public static string TextureNameInPosition(Vector3 playerPosition){

		float[] mix = getTexturesMix(playerPosition);

		float maxMix = 0;
		int maxIndex = 0;

		for(int n = 0; n < mix.Length; ++n){
			if(mix[n] > maxMix){
				maxIndex = n;
				maxMix = mix[n];
			}
		}

		SplatPrototype[] sp = Terrain.activeTerrain.terrainData.splatPrototypes;

		return sp[maxIndex].texture.name;
	}
		
}
