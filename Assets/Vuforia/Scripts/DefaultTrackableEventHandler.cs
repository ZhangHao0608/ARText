/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.Video;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES

        private GameObject Model;
        private GameObject Movie;
        private GameObject ModelBtn;
        private GameObject MovieBtn;

        public  VideoCtl m_VideoCtl;
        //public VideoPlayer MovieVideo;
        //private GameObject PauseBtn;
        //private Image PauseBtnImage;

        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            Model = GameObject.Find("Model");
            Movie = GameObject.Find("Movie");
            ModelBtn = GameObject.Find("ModelBtn");
            MovieBtn = GameObject.Find("MovieBtn");
            //PauseBtn = GameObject.Find("PauseBtn");
            //PauseBtnImage = transform.GetComponentInChildren<Image>();
            
            Model.SetActive(false);
            ModelBtn.SetActive(true);

            Movie.SetActive(true);
            MovieBtn.SetActive(false);
            
            
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }

            
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

            MovieBtn.SetActive(true);
            Model.SetActive(true);
            
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

            //MovieBtn.SetActive(false);
           // ModelBtn.SetActive(false);
            Movie.SetActive(false);
            m_VideoCtl.HideVideoPlay();
        }


        public void OnMovieBtnTrigger()
        {
            MovieBtn.SetActive(false);
            Movie.SetActive(true);
            m_VideoCtl.VideoPlay();

            ModelBtn.SetActive(true);
            Model.SetActive(false);
            
        }

        public void OnModelBtnTrigger()
        {
            ModelBtn.SetActive(false);
            Model.SetActive(true);

            MovieBtn.SetActive(true);
            Movie.SetActive(false);
            m_VideoCtl.HideVideoPlay();
        }
        #endregion // PRIVATE_METHODS
    }
}