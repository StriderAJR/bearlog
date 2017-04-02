<?php
  use yii\helpers\Html;
  use yii\bootstrap\ActiveForm;
?>


<div class="navbar navbar-default navbar-fixed-top">
  <div class="container">
    <div class="navbar-header">
      <a href="../" class="navbar-brand">
        <img src="img/logo.png">
      </a>
      <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
    </div>

    <div class="navbar-collapse collapse" id="navbar-main">
      <ul class="nav navbar-nav visible-xs">
        <li>
          <a href="#">Преимущества</a>
        </li>
        <li>
          <a href="#">Портфолио</a>
        </li>
        <li>
          <a href="#">Как стать участником ?</a>
        </li>
        <li>
          <a href="#">Контакты</a>
        </li>
      </ul>

      <?php if (!Yii::$app->user->isGuest): ?>
        <div class="logged-user-info">
          <?= Yii::$app->user->identity->email ?>
          <a href="/?logout=true" class="btn btn-success">Выйти</a>
        </div>
      <?php else: ?>
        <?php $form = ActiveForm::begin([
            'options' => [
              'class' => 'navbar-form navbar-right',
            ],
        ]); ?>
          <?= $form->field($model['entryForm'],  'email', [
                'errorOptions' => [
                    'tag' => 'div',
                    'class' => 'entry-form-error',
                    ],
                ])
            ->label('')
            ->textInput(['placeholder' => 'E-mail', 'id' => 'enrtyEmailInput', 'class' => 'form-control'])
          ?>
          <a class="grey-link font-small navbar-form-link go-to-register"><span>Зарегистрироваться</span></a>
          
          <?= $form->field($model['entryForm'],  'password', [
                'errorOptions' => [
                    'tag' => 'div',
                    'class' => 'entry-form-error',
                    ],
                ])
            ->label('')
            ->passwordInput(['placeholder' => 'Пароль', 'id' => 'entryPassInput', 'class' => 'form-control'])
          ?>
          <a href="#" class="grey-link font-small navbar-form-link"><span>Забыли пароль</span></a>
          <button type="submit" class="btn btn-success to-top">Войти</button>
        <?php ActiveForm::end(); ?>
      <?php endif; ?>


    </div>
    <div class="navbar-bottom hidden-xs">
     <ul class="nav navbar-nav">
        <li>
          <a href="#">Преимущества</a>
        </li>
        <li>
          <a href="#">Портфолио</a>
        </li>
        <li>
          <a href="#">Как стать участником?</a>
        </li>
        <li>
          <a href="#">Контакты</a>
        </li>
      </ul>
    </div>
  </div>

</div>


<div class="header fix-to-screen-height">
  <div class="header-main-info">
    <img src="img/track.png" alt="" class="main-track">
    <h1 class="main-header">
      Добро пожаловать в нашу Берлогу!
    </h1>
    <div class="sub-header">
      Bearlog - это новая инструментальная платформа <br>для переводчиков.
    </div>
  </div>
</div>

<div class="section section-placeholder-1 fix-to-screen-height ">
  <div class="container sr-section">
    <div class="row">
      <div class="col-xs-12">
        <h2>Секция 1</h2>
        <p>Nullam quis risus eget <a href="#">urna mollis ornare</a> vel eu leo. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam id dolor id nibh ultricies vehicula.</p>
        <p><small>This line of text is meant to be treated as fine print.</small></p>
        <p>The following snippet of text is <strong>rendered as bold text</strong>.</p>
        <p>The following snippet of text is <em>rendered as italicized text</em>.</p>
        <p>An abbreviation of the word attribute is <abbr title="attribute">attr</abbr>.</p>
      </div>
    </div>
  </div>
</div>

<div class="section section-placeholder-2 fix-to-screen-height">
  <div class="container sr-section">
    <div class="row">
      <div class="col-xs-12">
        <h2>Секция 2</h2>
        <p>Nullam quis risus eget <a href="#">urna mollis ornare</a> vel eu leo. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam id dolor id nibh ultricies vehicula.</p>
        <p><small>This line of text is meant to be treated as fine print.</small></p>
        <p>The following snippet of text is <strong>rendered as bold text</strong>.</p>
        <p>The following snippet of text is <em>rendered as italicized text</em>.</p>
        <p>An abbreviation of the word attribute is <abbr title="attribute">attr</abbr>.</p>
      </div>
    </div>
  </div>
</div>

<div class="section registration-section <?php if ($model['scrollToRegisterForm'] == true) echo 'scroll-to-me'; ?>">
  <div class="container sr-section">
    <div class="row registration-row">
      
    
    <div class="col-sm-6">
    <legend>Зарегистрируйтесь:</legend>
    <?php $form = ActiveForm::begin([
        'options' => [
          'class' => 'registration-form',
        ],
    ]); ?>
      
      <?= $form->field($model['signUpForm'],  'email', [
            'errorOptions' => [
                'tag' => 'div',
                'class' => 'auth-error',
                ],
            ])
        ->label('E-mail')
        ->textInput(['placeholder' => 'E-mail', 'id' => 'emailInput', 'class' => 'form-control'])
      ?>  

      <?= $form->field($model['signUpForm'],  'password', [
          'errorOptions' => [
              'tag' => 'div',
              'class' => 'auth-error',
              ],
          ])
        ->label('Придумайте пароль:')
        ->passwordInput(['placeholder' => 'Пароль', 'id' => 'passwordInput', 'class' => 'form-control'])
      ?> 

      <?= $form->field($model['signUpForm'],  'passwordRepeat', [
          'errorOptions' => [
              'tag' => 'div',
              'class' => 'auth-error',
              ],
            'options' => [
              'class' => 'last-form-control',
            ],
          ])
      ->label('Повторите пароль:')
      ->passwordInput(['placeholder' => 'Повторите пароль', 'id' => 'passwordRepeatInput', ])
      ?> 

      <button class="btn btn-default" type="submit" style="width:180px;">Зарегистрироваться</button>
    <?php ActiveForm::end(); ?>


    </div>

      <div class="col-sm-6">
          <legend>Или войдите с помощью:</legend>
          <div class="social-auth-wrapper">
            <button class="btn btn-social-auth"><i class="fa fa-facebook-official" aria-hidden="true"></i> Facebook</button>
            <button class="btn btn-social-auth"><i class="fa fa-vk" aria-hidden="true"></i> Вконтакте</button>
            <button class="btn btn-social-auth"><i class="fa fa-google-plus" aria-hidden="true"></i> Google +</button>
          </div>
      </div>
      </div>
    </div>
  </div>
</div>

<div class="footer">
  <div class="container">
    <div class="row">
      <div class="col-sm-3">
        <a href="#" class="footer-link">Преимущества</a>
        <a href="#" class="footer-link">Портфолио</a>
        <a href="#" class="footer-link">Как стать участником</a>
        <a href="#" class="footer-link">Контакты</a>
      </div>
      <div class="col-sm-4">
        <a href="#" class="footer-link">О сайте</a>
        <a href="#" class="footer-link">Создатели</a>
      </div>
      <div class="col-sm-5 text-right">
        <a href="#" class="footer-logo">
          <img src="img/logo.png" alt="">
        </a>
      </div>
    </div>
  </div>
</div>
<div class="copiryght">
  © Все права защищены!
</div>