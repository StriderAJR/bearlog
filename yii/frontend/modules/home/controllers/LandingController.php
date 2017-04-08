<?php
namespace app\modules\home\controllers;

use yii\web\Controller;
use Yii;

use frontend\modules\home\models\SignupForm;
use frontend\modules\home\models\EntryForm;

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
    
    public function actionIndex($logout = false)
    {
        if ($logout) {
            if (!Yii::$app->user->isGuest) {
                Yii::$app->user->logout();
            }
        }
        $signUpForm = new SignupForm();
        $entryForm = new EntryForm();

        if (Yii::$app->request->post()) {
            if ($signUpForm->load(Yii::$app->request->post()) 
                && $signUpForm->validatePasswordRepeat('passwordRepeat', [])
                && $signUpForm->validateEmail('email', [])) {
                if ($signUpForm->goSignUp()) {
                    return 'Пользователь был зарегистрирован!';
                }
            } else {
                if (isset(Yii::$app->request->post()["SignupForm"])) {
                    $scrollToRegisterForm = true;
                }
            }

            if ($entryForm->load(Yii::$app->request->post())) {
                if ($entryForm->login()) {
                    return $this->redirect(['/profile/feed']);
                }
            }
        }

        return $this->render('index', [
                'model' => [
                    'signUpForm' => $signUpForm, 
                    'entryForm' => $entryForm,
                    'scrollToRegisterForm' => isset($scrollToRegisterForm),
                ],
            ]);
    }
}