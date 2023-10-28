mergeInto(LibraryManager.library, {

    ShowFullscreenAdv: function () {
            ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function(wasShown) {
                    myGameInstance.SendMessage('LevelTransitions', 'EndShowAdvertisment');
                },
                onError: function(error) {
                // some action on error
                }
            }
        })
    },

    DetectBrowserAndEnableJoystick: function () {
        var isMobile = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
        
        myGameInstance.SendMessage('Player', 'EnableJoystick', isMobile);
    },

});