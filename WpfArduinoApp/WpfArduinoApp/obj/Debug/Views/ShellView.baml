   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   H DWpfArduinoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfArduinoApp.ViewsWpfArduinoApp.Views 5	   	   #   WpfArduinoApp.Views.ShellView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   h dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a^ ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai	 eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af
 bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   	 
                   5   	   Wlocal!clr-namespace:WpfArduinoApp.Views   	 
                   5	   	     � Title$  Arduino PhotoRegister��5   	   $	��600��6'   $	��700��64   .��5      � .+�5   
   o� $��0��6   $��10,8,10,528q�6   .@�5      m� $��파일��6   .@�5      m� $��열기��6    m� Icon 5      .  (MahApps.Metro.IconPacks.PackIconIonicons  5         Kind$ FolderOpeniOS=�65   
��� � �6J   5      m� 5      $��저장��6    5      .  (MahApps.Metro.IconPacks.PackIconBoxIcons  5         Kind$ 	SolidSave=�65   
��� � �6F   5      �� 5      m� 5      -   5         m�Name$ MenuSubItemExit��5      $��종료��64    5        5      $ 	SolidExit=�65   
��� � �6F   5      5      m� 5       $��시뮬레이션��6   .@�5!      m� -   5        $ MenuSubItemStart��5!      $��시작��65   6A   m� 5"      -   5        $ MenuSubItemStop��5"      $��중지��64   6@   5#      m� 5$      $��	도움말��6   .@�5%      m� -   5        $ MenuSubItemInfo��5%      $��정보��64   6@   5&      5'      �� 5(   
   -   5        $��LblConnectionTime��5(      $��연결 시간 :��6)   $
��Left=�6;   $��	11,45,0,0q�6V   $	��Top=�6i   �� 5)   
   $��포토레지스터��6   $
��Left=�6#   $	��110��6>   $��	10,84,0,0q�6K   $	��Top=�6^   $	��457��6v   �� 5*   
   $��포트��6   $
��Left=�6   $	��232��6:   $��
471,48,0,0q�6G   $	��Top=�6[   $	��211��6s   �� 5+   
   -   5        $��TxtSensorCount��5+      $
��Left=�6(   $��23��6C   $��
346,47,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��120��6�   �� 5,   
   -   5        $��RtbLog��5,         ConsoleTextBox#��[  6    $
��Left=�6H   $��81��6c   $��
10,199,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��456��6�    �� 
IsReadOnly . 6�   � 5-   
   -   5        $��PgbPhotoRegistor��5-      $
��Left=�6.   $��32��6I   $��
15,120,0,0q�6U   $	��Top=�6i   $	��446��6�   �� 5.   
   -	   5        $��TxbPhotoRegistor��5.      $
��Left=�6,   $��204,165,0,0q�6G   $
��Wrap=�6\   $	��Top=�6p   $��76��6�   �� 5/   
   -
   5         ��Name$ CboSerialPort��5/      $
��Left=�6*   $��
477,78,0,0q�6E   $	��Top=�6Y   $	��200��6q   $��25��6}   6�   �� 50   
   -   5         ��Name$ 
BtnConnect��50      $��CONNECT��6%   $
��Left=�67   $��477,109,0,0q�6R   $	��Top=�6g   $	��200��6   $��40��6�   6�   �� 51   
   -   5        $ BtnDisconnect��51      $��
DISCONNECT��6(   $
��Left=�6=   $��477,154,0,0q�6X   $	��Top=�6m   $	��200��6�   $��40��6�   6�   �� 52   
   -   5        $ BtnPortValue��52      $
��PORT��6'   $
��Left=�66   $��477,199,0,0q�6Q   $	��Top=�6f   $	��200��6~   $��75��6�   #   LiveCharts.Wpf.CartesianChart  53   
   -   5        	  Name$	 ChtPhoto��53      $��65,329,65,55q�6M   
 J� RenderTransformOrigin$
 0.5,0.5&�6c   &    LiveCharts.Wpf.Charts.Base.Chart   Series 6/   �� *
LineValues+54      55      56      