using ReadyPlayerMe.Core;
using UnityEngine;

namespace ReadyPlayerMe.Samples.AvatarLoading
{
    /// <summary>
    /// This class is a simple <see cref="Monobehaviour"/>  to serve as an example on how to load Ready Player Me avatars and spawn as a <see cref="GameObject"/> into the scene.
    /// </summary>
    public class AvatarLoadingExample : MonoBehaviour
    {
        [SerializeField] [Tooltip("Set this to the URL or shortcode of the Ready Player Me Avatar you want to load.")]
        private string avatarUrl = "https://models.readyplayer.me/638df693d72bffc6fa17943c.glb";

        private GameObject avatar;
        public Transform baseFemaleAvatarHead;
        public Transform baseMaleAvatarHead;

        public Transform[] baseMaleAvatarHands;
        public Transform[] baseFemaleAvatarHands;

        public GameObject[] baseBaseAvatar;
        public GameObject baseAvatar;

        public GameObject OVR;
        public SkinnedMeshRenderer[] meshRenderers;

        public bool shouldRepeat;

        private void Start()
        {
            if (shouldRepeat)
            {
                TextEditor textEditor = new TextEditor();
                textEditor.multiline = true;
                textEditor.Paste();
                avatarUrl = textEditor.text;
                ApplicationData.Log();
                var avatarLoader = new AvatarObjectLoader();
                // use the OnCompleted event to set the avatar and setup animator
                avatarLoader.OnCompleted += (_, args) =>
                {
                    avatar = args.Avatar;
                    int index = 0;
                    if (avatar.GetComponent<Animator>().avatar.name == "MasculineAvatar")
                    {
                        baseAvatar = baseBaseAvatar[0];
                        baseBaseAvatar[1].SetActive(false);
                        index += 10;
                        //OVR.transform.position = new Vector3(baseMaleAvatarHead.position.x, baseMaleAvatarHead.position.y, baseMaleAvatarHead.position.z);
                        /*OVR.transform.parent = baseMaleAvatarHead;
                        OVR.transform.localPosition = Vector3.zero;*/
                        HandCollision[] hand = FindObjectsOfType<HandCollision>();
                        for (int a = 0; a < hand.Length; a++)
                        {
                            hand[a].leftHand = baseMaleAvatarHands[0];
                            hand[a].rightHand = baseMaleAvatarHands[1];
                        }
                    }
                    else
                    {
                        baseAvatar = baseBaseAvatar[1];
                        baseBaseAvatar[0].SetActive(false);
                        //OVR.transform.position = new Vector3(baseFemaleAvatarHead.position.x, baseFemaleAvatarHead.position.y, baseFemaleAvatarHead.position.z);
                        HandCollision[] hand = FindObjectsOfType<HandCollision>();
                        for (int a = 0; a < hand.Length; a++)
                        {
                            hand[a].leftHand = baseFemaleAvatarHands[0];
                            hand[a].rightHand = baseFemaleAvatarHands[1];
                        }
                    }
                    SkinnedMeshRenderer[] newMeshRenderer = avatar.GetComponentsInChildren<SkinnedMeshRenderer>();
                    AvatarAnimationHelper.SetupAnimator(args.Metadata, args.Avatar);      
                    for (int a = 0; a < newMeshRenderer.Length; a++)
                    {
          //              Debug.Log(newMeshRenderer.Length);
                        if (newMeshRenderer.Length == 9 && (a == 5))
                        {
                            Destroy(meshRenderers[index].gameObject);
                            index++;
                        }
                        meshRenderers[index].sharedMesh = newMeshRenderer[a].sharedMesh;
                        meshRenderers[index].material = newMeshRenderer[a].material;
                        index++;
                    }
                    avatar.SetActive(false);
                };
                avatarLoader.LoadAvatar(avatarUrl);
            }
        }

        private void OnDestroy()
        {
            if (avatar != null) Destroy(avatar);
        }
    }
}
