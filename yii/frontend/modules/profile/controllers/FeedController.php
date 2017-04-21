<?php
namespace app\modules\profile\controllers;

use yii\web\Controller;
use Yii;

use frontend\models\Translation;

class FeedController extends Controller 
{
	public function behaviors()
    {
        return [
            'access' => [
                'class' => \yii\filters\AccessControl::className(),
                'rules' => [
                    [
                        'allow' => false,
                        'roles' => ['?'],
                    ],
                    [
                        'allow' => true,
                        'roles' => ['@'],
                    ],
                ],
            ],
        ];
    }
    
    public function actionIndex()
    {   
        $model = [];
        $model['translations'] = Translation::getUserTranslations(Yii::$app->user->identity->user_id);

        return $this->render('index', [
                'model' => $model,
            ]);
    }
}