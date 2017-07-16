//
//  AppnextUnityPlugin.h
//  AppnextUnityPlugin
//
//  Created by Eran Mausner on 02/08/2016.
//  Copyright © 2016 Appnext. All rights reserved.
//

#ifndef AppnextUnityPlugin_h
#define AppnextUnityPlugin_h

#ifdef __cplusplus
extern "C"
#else
extern
#endif
{
    // Global SDK Methods
    const char* appnextGetApiVersion();

    // Config default getters
    const char* appnextGetConfigDefaultString(const char* configParamName);
    bool appnextGetConfigDefaultBool(const char* configParamName);
    double appnextGetConfigDefaultDouble(const char* configParamName);
    
    // Ad Managment Methods
    const char* appnextCreateAd(const char* adTypeName, const char* placementID);
    void appnextDisposeAd(const char* adKey);

    void appnextLoadAd(const char* adKey);
    void appnextShowAd(const char* adKey);
    bool appnextAdIsLoaded(const char* adKey);

    // Ad Setters/Getters Methods

    void appnextSetButtonText(const char* adKey, const char* buttonText);
    void appnextSetButtonColor(const char* adKey, const char* buttonColor);
    void appnextSetCategories(const char* adKey, const char* categories);
    void appnextSetPostback(const char* adKey, const char* postback);
    void appnextSetOrientation(const char* adKey, const char* orientation);

    // Video Ad Setters/Getters Methods

    void appnextSetSkipText(const char* adKey, const char* skipText);
    void appnextSetCreativeType(const char* adKey, const char* creativeType);
    void appnextSetAutoPlay(const char* adKey, bool autoPlay);

    // Video Ad Setters/Getters Methods

    void appnextSetMute(const char* adKey, bool mute);
    void appnextSetProgressType(const char* adKey, const char* progressType);
    void appnextSetProgressColor(const char* adKey, const char* progressColor);
    void appnextSetVideoLength(const char* adKey, const char* videoLength);
    void appnextSetShowClose(const char* adKey, bool showClose);
    void appnextSetCloseDelay(const char* adKey, double delay);

    // Rewarded Video Ad Setters/Getters Methods

    void appnextSetRewardsTransactionId(const char* adKey, const char* rewardsTransactionId);
    void appnextSetRewardsUserId(const char* adKey, const char* rewardsUserId);
    void appnextSetRewardsRewardTypeCurrency(const char* adKey, const char* rewardsRewardTypeCurrency);
    void appnextSetRewardsAmountRewarded(const char* adKey, const char* rewardsAmountRewarded);
    void appnextSetRewardsCustomParameter(const char* adKey, const char* rewardsCustomParameter);
    
    // Callback Methods - All Ads Callbacks
    void appnextSetOnAdLoadedCallback(const char* adKey, const char* gameObject, const char* method);
    void appnextSetOnAdOpenedCallback(const char* adKey, const char* gameObject, const char* method);
    void appnextSetOnAdClosedCallback(const char* adKey, const char* gameObject, const char* method);
    void appnextSetOnAdClickedCallback(const char* adKey, const char* gameObject, const char* method);
    void appnextSetOnAdErrorCallback(const char* adKey, const char* gameObject, const char* method);
    
    // Callback Methods - Video Ads Callback
    void appnextSetOnVideoEndedCallback(const char* adKey, const char* gameObject, const char* method);
}

#endif /* AppnextUnityPlugin_h */
