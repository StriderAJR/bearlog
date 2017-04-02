<?php
namespace app\modules\home\controllers;

use yii\web\Controller;
use Yii;

use frontend\modules\home\models\SignupForm;

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
        // if (!Yii::$app->user->isGuest) {
        //     Yii::$app->user->logout();
        // }
        // if (Yii::$app->request->post()) {
        //     var_dump(Yii::$app->request->post());
        //     exit();
        // }
        $signUpForm = new SignupForm();
        $signUpForm->load(Yii::$app->request->post());

        if ($signUpForm->load(Yii::$app->request->post())) {
            $signUpForm->signup();
            return 'Signed UP';
        }

        return $this->render('index', [
                'model' => [
                    'signUpForm' => $signUpForm, 
                ],
            ]);
    }
}