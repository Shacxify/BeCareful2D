using UnityEngine;

		public class dndol: MonoBehaviour
		{
				private static dndol instanceRef;

				void Awake()
				{
						if(instanceRef == null)
						{
								instanceRef = this;
								DontDestroyOnLoad(gameObject);
						}else
						{
								DestroyImmediate(gameObject);
						}
				}


		}
