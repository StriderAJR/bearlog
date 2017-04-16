<?php
namespace app\modules\translation\controllers;

use yii\web\Controller;
use Yii;

class CreationController extends Controller 
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
        return $this->render('index', []);
    }

    public function actionUpload()
    {
        return $this->render('upload', []);   
    }

    public function actionFragmentation()
    {
        return $this->render('fragmentation', []);           
    }

    public function actionCheck()
    {
        return $this->render('check', []);           
    }
}