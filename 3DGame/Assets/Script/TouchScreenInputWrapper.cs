using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
    /*
    Instead of:
    Touch[] _touches = Input.touches;
    Use:
    Touch[] _touches = TouchScreenInputWrapper.touches;
    */

    public static class TouchScreenInputWrapper
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        private static Touch? lastFakeTouch;
        /// <summary>
        /// When delta position lower with this value, count as stationary
        /// </summary>
        const float stationaryDeltapos = 3.0f;
#endif
        public static Touch[] touches
        {
            get
            {
#if UNITY_EDITOR || UNITY_STANDALONE
                if (lastFakeTouch == null)
                    lastFakeTouch = new Touch();

                Touch lastFakeTouchStruct = (Touch)lastFakeTouch;
                if (Input.GetMouseButtonDown(0))
                {
                    lastFakeTouchStruct.phase = TouchPhase.Began;
                    lastFakeTouchStruct.deltaPosition = new Vector2(0, 0);
                    lastFakeTouchStruct.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                    lastFakeTouchStruct.fingerId = 0;
                }
                else if (Input.GetMouseButton(0))
                {
                    lastFakeTouchStruct.phase = TouchPhase.Moved;
                    Vector2 newPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                    lastFakeTouchStruct.deltaPosition = newPosition - lastFakeTouchStruct.position;
                    lastFakeTouchStruct.position = newPosition;
                    lastFakeTouchStruct.fingerId = 0;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    lastFakeTouchStruct.phase = TouchPhase.Ended;
                    Vector2 newPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                    lastFakeTouchStruct.deltaPosition = newPosition - lastFakeTouchStruct.position;
                    lastFakeTouchStruct.position = newPosition;
                    lastFakeTouchStruct.fingerId = 0;
                }
                else
                {
                    lastFakeTouch = null;
                }

                // will be inaccurate if called more than once per frame
                lastFakeTouchStruct.deltaTime = Time.deltaTime;

                if (lastFakeTouch != null)
                {
                    //If the didn't move much, change the touch phase to stationary
                    if (lastFakeTouchStruct.phase == TouchPhase.Moved)
                    {                       
                        if (lastFakeTouchStruct.deltaPosition.magnitude < stationaryDeltapos)
                        {
                            lastFakeTouchStruct.phase = TouchPhase.Stationary;
                        }
                    }
                    lastFakeTouch = lastFakeTouchStruct;
                    return new Touch[] { lastFakeTouchStruct };
                }
                else
                    return new Touch[0];
#endif

                return Input.touches;
            }
        }
    }