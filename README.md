# EECS495 Mixed Reality Project - Gameday

## Abstract

#### Keywords
Accessibility, Virtual Reality, Interactive and Immersive experience, Children, Live Sports Events

#### Background
Hospitalization can be an unpleasant experience for pediatric patients, especially kids when they suffer from physical pains caused by diseases and/or suffer from isolation to events happening outside the hospital. Providing meaningful enrichment activities besides medical care can greatly reduce patients’ stress and provide them opportunities to interact with outside world.

#### Objectives
* Use available VR / MR technology (e.g. Acer Mixed Reality Headset) to provide an opportunity for short- / long-term pediatric patients at CS Mott Children’s Hospital to virtually observe and participate in some live UM athletic event(s). 
* Use haptic, audible and visual feedbacks based on VR / MR headsets to make game watching an immersive experience, involving virtually sitting in the stadium, interacting with players, and interacting with other patients.
* Future direction: Make some VR sports games available to patients at halftime to relax

#### End Users
People with various abilities

## Group Formation (Not ranked by contribution)
Zijian Xie, Zhengxi Tan, Jacob Hage, Quentin Metzmaker

## Acknowledgement
Thanks to Professor David Chesney and professor Michael Nebelign and EECS at University of Michigan for their support.

## Design Rendering
![Goal](/Images/Effects.png)

## Implementation
We choose Windows Mixed Reality Headsets as a proof-of-concept VR hardware.  
Our 360 camera is narrowed down to Theta Ricoh S and Theta Ricoh V for their supportive developer community.  
Our VR live streaming is leveraging Microsoft Azure cloud service and have a 30s latency.  
![Technical Structure for live streaming](/Images/workflow.png)

## Alpha Release
For the Alpha Release, we primarily focus on delivering the core functionality 
of our project, which is the ability to offer our users an immersive 360 viewing experience. The following are the three main features plus a starting page
introduced in the Alpha Release.

#### Starting page
We created a starting page which serves as the initial entry point to the whole program. Users can press the trigger on the controller to
continue to the streaming view.

#### Adjust viewing angle with the thumbstick
The users can use the thumbstick to adjust the angle of the view so that they can navigate the immersive 360 viewing setting seamlessly.

#### Switch scenes with the touchpad
The users can press the touchpad to switch the current scene to the next one. The intended use case for this feature is for our users, specifically
those with decent motions in their hands, to switch to different channels(e.g., ESPN1 to ESPN2). 

#### Switch scenes by looking at the text message
In order to accommodate users with limited capability in their hands, we create this feature so that users can smoothly switch scenes
only by looking at the text message in the view.

## Beta Release
For the Beta Release, we continue working on improving the overall user experience and accessibility of our application. 
We created a tooltip menu with several new features to enable users to better navigate the whole application. 
The following is a brief overview of features newly incorporated in the tooltip menu:

#### Channel Selection
Previously, if users want to switch to a specific channel, they need to do that by going through all the channels one by one. 
Now, with the newly implemented channel button on the menu, users can directly select and jump to the desired channel. 

#### Volume Adjustment
Users can easily adjust the volume of the current channel by clicking on the up and down volume button.

#### Chat Room
Users can better engage in the game to share their thoughts and feelings by communicating with other users using text messages, 
regardless of the channels they are currently watching.

## Final Product
#### User Interface
![User Interface](/Images/ui.png)

#### Live Chat Feature
![Live Chat](/Images/livechat.png)

#### Live Streaming feature
![Live Streaming](/Images/livestreaming.png)

