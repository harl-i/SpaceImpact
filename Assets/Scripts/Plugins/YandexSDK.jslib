mergeInto(LibraryManager.library, {
    ShowFullscreenAdv: function () {
        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function(wasShown) {
                    myGameInstance.SendMessage('LevelTransitions', 'EndShowAdvertisment');
                },
                onError: function(error) {
                    console.error("ShowFullScreenAdv: " + error);
                }
            }
        })
    },

    DetectBrowserAndEnableMobileButtons: function () {
        var isMobile = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
        var isMobileNumber = +isMobile;
        myGameInstance.SendMessage('Player', 'EnableMobileButtons', isMobileNumber);
        myGameInstance.SendMessage('Exit', 'EnableMobileButtons', isMobileNumber);
        myGameInstance.SendMessage('ControlsButton', 'SwitchControlMethodBasedOnPlatform', isMobileNumber);
    },

    SetBackgroundColor: function (r, g, b, a) {
        var color = 'rgba(' + r * 100 + ',' + g * 100 + ',' + b * 100 + ',' + a + ')';
        var element = document.getElementById('canvas-container');
        element.style.backgroundColor = color;
    },

    GetLang: function(){
        var lang = ysdk.environment.i18n.lang;
        var bufferSize = lengthBytesUTF8(lang) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(lang, buffer, bufferSize);
        return buffer;
    },

    SetLeaderboardScore: function(score) {
        ysdk.getPlayer().then(_player => {
            player = _player;
            if (player.getMode() === 'lite') {
                ysdk.auth.openAuthDialog().then(() => {
                    updateLeaderboardScore(player, score);
                }).catch(() => {
                    console.error("Player declined authorization");
                });
            } else {
                updateLeaderboardScore(player, score);
            }
        }).catch(err => {
            console.error("Initialization error: " + err.message);
        });

        function updateLeaderboardScore(player, score) {
            ysdk.getLeaderboards().then(lb => {
                lb.getLeaderboardPlayerEntry('SpaceImpactLeaderboard').then(currentEntry => {
                    if (score > currentEntry.score) {
                        lb.setLeaderboardScore('SpaceImpactLeaderboard', score);
                    }
                }).catch(err => {
                    console.error("Error getting leaderboard entry: " + err.message);
                });
            }).catch(err => {
                console.error("Error getting leaderboards: " + err.message);
            });
        }
    },
});