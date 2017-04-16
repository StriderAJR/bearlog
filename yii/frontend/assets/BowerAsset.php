<?php

namespace frontend\assets;

use yii\web\AssetBundle;

/**
 * Main frontend application asset bundle.
 */
class BowerAsset extends AssetBundle
{

    public $sourcePath = '@bower';
    public $css = [
        'ion-checkradio/css/ion.checkRadio.css',
        'ion-checkradio/css/ion.checkRadio.html5.css',
    ];

    public $js = [
        'ion-checkradio/js/ion.checkRadio.min.js',
    ];

}