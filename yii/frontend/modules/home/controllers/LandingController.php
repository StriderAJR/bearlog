<?php
namespace app\modules\home\controllers;

use yii\web\Controller;
use Yii;

class LandingController extends Controller 
{
	public function behaviors()
    {
        return [
            'access' => [
                'class' => \yii\filters\AccessControl::className(),
                'rules' => [
                    [
                        'allow' => true,
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
    
    public function init()
    {
        parent::init();
        $this->layout = 'landing';
    }
    
    public function actionIndex()
    {
        // $model = SomeModel::loadData();
        return $this->render('index', []);
    }
}