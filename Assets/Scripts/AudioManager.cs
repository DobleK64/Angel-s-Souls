using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private List<GameObject> audioList;
    // Start is called before the first frame update
    void Awake()
    {
        if (!instance) //si instance no tiene informacion
        {
            instance = this; //instance se asigna a este objeto
            DontDestroyOnLoad(gameObject); // se indica que esre obj no se destruya con la carga de escenas
        }
        else
        {
            Destroy(gameObject); // se destruye el gameobject, para que no haya dos o mas gms en el juego
        }
        audioList = new List<GameObject>();
    }

    // Update is called once per frame
    public AudioSource PlayAudio(AudioClip audioClip, string gameObjectName, bool isLoop = false, float volume = 1.0f) //isLoop y floatvolume son parametros por defecto,
                                                                                                                       //tienen que ir al final siempre y no pueden estar intercalados

    {
        GameObject audioObject = new GameObject(gameObjectName);
        audioObject.transform.SetParent(transform); //todos los audios que se van creando son hijos del AudioManager
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>(); //añado a GameObject nuevo componente AudioSource
        audioSourceComponent.clip = audioClip; //le asignamos el clip al componente y el clip que le asignamos es nuestro metodo
        audioSourceComponent.volume = volume; //la variable del volumen
        audioSourceComponent.loop = isLoop;
        audioSourceComponent.Play();
        audioList.Add(audioObject); //llevar un seguimiento de los objetos que estan sonando en la escena.
        if (!isLoop) // si el audio no esta en loop espero a que acabe para destruirlo
        {
            StartCoroutine(WaitAudioEnd(audioSourceComponent));
        }


        return audioSourceComponent;
    }//IEnumerator es una corrutina que tiene Unity para crear una epsecie de hilos y procesos

    public AudioSource PlayAudio3D(AudioClip audioClip, string gameObjectName, bool isLoop = false, float volume = 1.0f)
    {
        AudioSource audioSource = PlayAudio(audioClip, gameObjectName, false, volume);
        audioSource.spatialBlend = 1f;

        return audioSource;
    }

    IEnumerator WaitAudioEnd(AudioSource src) //este bucle espera a que src deje de sonar para destruirlo
    {
        while (src && src.isPlaying)
        {
            yield return null; //yield le devuelve el control a Unity
        }

        Destroy(src.gameObject);
    }

    public void ClearAudios()
    {
        foreach (GameObject audioObject in audioList)
        {
            Destroy(audioObject);
        }
        audioList.Clear();
        StopAllCoroutines();
    }
}
