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

    DetectBrowserAndEnableMobileButtons: function () {
        var isMobile = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);

        var isMobileNumber = +isMobile;
        myGameInstance.SendMessage('Player', 'EnableMobileButtons', isMobileNumber);
        myGameInstance.SendMessage('Exit', 'EnableMobileButtons', isMobileNumber);
    },

    SetBackgroundColor: function (r, g, b, a) {
        var color = 'rgba(' + r * 100 + ',' + g * 100 + ',' + b * 100 + ',' + a + ')';
        var element = document.getElementById('canvas-container');

        element.style.backgroundColor = color;

    },

    GetLang: async function(){
        await window.ysdkInitialized;
        var lang = ysdk.environment.i18n.lang;
        var bufferSize = lengthBytesUTF8(lang) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(lang, buffer, bufferSize);

        alert("---!!!GetLang done!!!---")
        
        return buffer;
    },

    SetLeaderboardScore : function(score){
        var player;
        ysdk.getPlayer().then(_player => {
            player = _player;
            if (player.getMode() !== 'lite') {
                ysdk.getLeaderboards()
                .then(lb => {
                    lb.setLeaderboardScore('SpaceImpactLeaderboard', score);
                });
            } else {
                player.signIn();
            }
            }).catch(err => {
                    alert("Initialization error");
            });
    },

});