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

    // SetLeaderboardScore: function(score) {
    //     ysdk.getPlayer().then(_player => {
    //         player = _player;
    //         if (player.getMode() === 'lite') {
    //             ysdk.auth.openAuthDialog().then(() => {
    //                 updateLeaderboardScore(player, score);
    //             }).catch(() => {
    //                 console.error("Player declined authorization");
    //             });
    //         } else {
    //             updateLeaderboardScore(player, score);
    //         }
    //     }).catch(err => {
    //         console.error("Initialization error: " + err.message);
    //     });

    //     function updateLeaderboardScore(player, score) {
    //         ysdk.getLeaderboards().then(lb => {
    //             lb.getLeaderboardPlayerEntry('SpaceImpactLeaderboard').then(currentEntry => {
    //                 if (score > currentEntry.score) {
    //                     lb.setLeaderboardScore('SpaceImpactLeaderboard', score).then(() => {
    //                         // Вызывает Unity метод при успешном обновлении счета
    //                         myGameInstance.SendMessage('Messages', 'OnScoreUpdatedSuccessfully', score);
    //                     }).catch(err => {
    //                         // Вызывает Unity метод в случае ошибки при обновлении счета
    //                         myGameInstance.SendMessage('Messages', 'OnScoreUpdateError', score);
    //                         console.error("Error setting leaderboard score: " + err.message);
    //                     });
    //                 } else {
    //                     // Вызывает Unity метод, если новый счет меньше текущего
    //                     myGameInstance.SendMessage('Messages', 'OnScoreUpdateFailed', score);
    //                 }
    //             }).catch(err => {
    //                 // Если не удалось получить текущий счет или другая ошибка
    //                 myGameInstance.SendMessage('Messages', 'OnScoreUpdateError', score);
    //                 console.error("Error getting leaderboard entry: " + err.message);
    //             });
    //         }).catch(err => {
    //             console.error("Error getting leaderboards: " + err.message);
    //         });
    //     }
    // },

    SetLeaderboardScore: function(score) {
        function updateLeaderboardScore(player, score) {
            ysdk.getLeaderboards().then(lb => {
                lb.getLeaderboardPlayerEntry('SpaceImpactLeaderboard').then(currentEntry => {
                    if (score > currentEntry.score) {
                        lb.setLeaderboardScore('SpaceImpactLeaderboard', score).then(() => {
                            myGameInstance.SendMessage('Messages', 'OnScoreUpdatedSuccessfully', score);
                        }).catch(err => {
                            myGameInstance.SendMessage('Messages', 'OnScoreUpdateError', score);
                            console.error("Error setting leaderboard score: " + err.message);
                        });
                    } else {
                        myGameInstance.SendMessage('Messages', 'OnScoreUpdateFailed', score);
                    }
                }).catch(err => {
                    if (err.code === 'LEADERBOARD_PLAYER_NOT_PRESENT') {
                        lb.setLeaderboardScore('SpaceImpactLeaderboard', score).then(() => {
                            myGameInstance.SendMessage('Messages', 'OnScoreUpdatedSuccessfully', score);
                        }).catch(err => {
                            myGameInstance.SendMessage('Messages', 'OnScoreUpdateError', score);
                            console.error("Error setting leaderboard score: " + err.message);
                        });
                    } else {
                        myGameInstance.SendMessage('Messages', 'OnScoreUpdateError', score);
                        console.error("Error getting leaderboard entry: " + err.message);
                    }
                });
            }).catch(err => {
                console.error("Error getting leaderboards: " + err.message);
            });
        }

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
    },

    SaveToLocalStorage: function(key, data){
       localStorage.setItem(UTF8ToString(key), UTF8ToString(data));
    },

    LoadFromLocalStorage: function(key){
       var returnStr = "";

       if(localStorage.getItem(UTF8ToString(key)) !==null)
       {
           returnStr = localStorage.getItem(UTF8ToString(key));
       }

       var bufferSize = lengthBytesUTF8(returnStr) + 1;
       var buffer = _malloc(bufferSize);
       stringToUTF8(returnStr, buffer, bufferSize);
       return buffer;
    },

    ClearLocalStorage: function(key){
       localStorage.removeItem(UTF8ToString(key));
    }
});