using UnityEngine;
using System;


namespace UnityStandardAssets.ImageEffects
{
	[ExecuteInEditMode]
	public class RadialBlur : ImageEffectBase
	{
		public float blurStrength = 2.2f;
		public float blurWidth = 1.0f;
		public Vector2 blurCenter = new Vector2(0.5f,0.5f);

		private bool isOpenGL;
		
		private RenderTexture accumTexture;
		
		override protected void Start()
		{
			isOpenGL = SystemInfo.graphicsDeviceVersion.StartsWith("OpenGL");

			if (!SystemInfo.supportsRenderTextures)
			{
				enabled = false;
				return;
			}
			base.Start();

		}

		override protected void OnDisable()
		{
			base.OnDisable();
			DestroyImmediate(accumTexture);
		}
		
		void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			//If we run in OpenGL mode, our UV coords are
			//not in 0-1 range, because of the texRECT sampler
			float ImageWidth = 1;
			float ImageHeight = 1;
			/*
			if (isOpenGL)
			{
				ImageWidth = source.width;
				ImageHeight = source.height;
			}
			*/
			
			material.SetFloat("_BlurStrength", blurStrength);
			material.SetFloat("_BlurWidth", blurWidth);
			material.SetFloat("_iHeight",ImageWidth);
			material.SetFloat("_iWidth", ImageHeight);
			material.SetFloat("_BlurCenterX", blurCenter.x);
			material.SetFloat("_BlurCenterY", blurCenter.y);

			// Create the accumulation texture
			if (accumTexture == null || accumTexture.width != source.width || accumTexture.height != source.height)
			{
				DestroyImmediate(accumTexture);
				accumTexture = new RenderTexture(source.width, source.height, 0);
				accumTexture.hideFlags = HideFlags.HideAndDontSave;
				//Graphics.Blit( source, accumTexture );
			}

			//ImageEffects.BlitWithMaterial(GetMaterial(), source, dest);

			// We are accumulating motion over frames without clear/discard
			// by design, so silence any performance warnings from Unity
			//accumTexture.MarkRestoreExpected();
			
			// Render the image using the motion blur shader
			Graphics.Blit (source, accumTexture, material);
			Graphics.Blit (accumTexture, destination);
		}
	}
}